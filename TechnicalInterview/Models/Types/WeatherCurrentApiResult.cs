namespace PlaceInTecnicalInterview.Models.Types
{
    public class WeatherCurrentApiResult
    {
        public Current current { get; set; }
    }

    public class Current
    {
        public int temperature { get; set; }
        public int humidity { get; set; }
    }
}
