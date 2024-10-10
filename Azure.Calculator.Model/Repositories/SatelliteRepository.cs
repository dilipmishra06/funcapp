using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Fl.Azure.Calculator.External.Connectivity.Probe.Helpers;
using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;
using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Model.Repositories
{
    internal class SatelliteRepository : ISatelliteRepository, IValidateConnection
    {
        private readonly SatelliteContext _satelliteContext;
        public SatelliteRepository(SatelliteContext satelliteContext)
        {
            _satelliteContext = satelliteContext;
            

        }


        public async Task<IReadOnlyCollection<BalanceSheet>> LoadBalanceSheets(string satelliteRunId, int partitionId, string scenario)
        {
            return await _satelliteContext.BalanceSheet
                .Where(b =>
                    b.SatelliteRunID == satelliteRunId &&
                    b.Scenario == scenario &&
                    b.PartitionID == partitionId)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<Staging>> LoadStaging(string satelliteRunId, int partitionId)
        {
            return await _satelliteContext.Staging
                .Where(s =>
                    s.SatelliteRunID == satelliteRunId &&
                    s.PartitionID == partitionId)
                .ToListAsync();
        }

        public async Task<Status?> GetLatestStatus(string closeOfBusinessDate)
        {
           
            
            return await _satelliteContext.Status
                .Where(s => s.SatelliteRunID != null && s.SatelliteRunID.StartsWith(closeOfBusinessDate))
                .OrderByDescending(s => s.SatelliteRunID)
                .FirstOrDefaultAsync();
        }

        public async Task SaveStaging(IEnumerable<Staging> stagingRecords)
        {
            
            await _satelliteContext.TruncateAsync<Staging>();
            await _satelliteContext.BulkInsertAsync(stagingRecords);
        }

        public async Task SaveBalanceSheets(IEnumerable<BalanceSheet> balanceSheetRecords)
        {
            await _satelliteContext.BulkInsertAsync(balanceSheetRecords);
        }

        public async Task SaveCashflowMetricResults(IEnumerable<CashflowMetricResult> cashflowMetricResultRecords)
        {
            await _satelliteContext.BulkInsertAsync(cashflowMetricResultRecords);
        }

        public async Task SaveMetricAggregationResults(IEnumerable<MetricAggregationResult> metricAggregationResultRecords)
        {
            _satelliteContext.MetricAggregationResult.AddRange(metricAggregationResultRecords);
            await _satelliteContext.SaveChangesAsync();
        }

        public async Task SaveStatus(Module module, string message, StatusInfo statusInfo)
        {
           
            _satelliteContext.Status.Add(new Status
            {
                Message = message,
                Initiator = module.ToString(),
                SatelliteRunID = statusInfo.SatelliteRunID,
                Scenario = statusInfo.Scenario,
                PartitionID = statusInfo.PartitionID,
                Metric = statusInfo.Metric,
                AggregationMetric = statusInfo.MetricAggregation,
                TimeStamp = DateTime.UtcNow
            });

            await _satelliteContext.SaveChangesAsync();
        }
        async Task<IProbeResult[]> IValidateConnection.ValidateConnection(CancellationToken cancellationToken)
        {
            return [await ValidateConnectionAsync("SatelliteContext")];


            async Task<IProbeResult> ValidateConnectionAsync(string name)
            {
                try
                {
                    var _ = await _satelliteContext.Status
                    .OrderBy(x => x.ID)
                        .FirstOrDefaultAsync(cancellationToken);

                    return ProbeResult.Pass(name);
                }
                catch (Exception ex)
                {
                    return ProbeResult.Fail(name, ex);
                }
            }
        }
    }
}
