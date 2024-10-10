namespace Fl.Azure.Calculator.Core
{
    public static class SatelliteRunIdCreator
    {
        public static string Next(string? lastSatelliteRunID, string closeOfBusinessDate)
        {
            if (lastSatelliteRunID is null || !lastSatelliteRunID.Contains("_"))
                return $"{closeOfBusinessDate}_00001";

            string runID = lastSatelliteRunID.Split('_').Last();
            int runIDNumber = int.TryParse(runID, out var value) ? value : 0;
            runIDNumber++;

            return $"{closeOfBusinessDate}_{runIDNumber:D5}";
        }
    }
}
