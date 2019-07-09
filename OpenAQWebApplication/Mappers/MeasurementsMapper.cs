using System.Collections.Generic;

namespace OpenAQ.Mappers
{
    public class MeasurementsMapper
    {
        public static List<MeasurementsDTO> MapMeasurements(List<MeasurementsInfo> measurementsInfo)
        {
            var measurementsDTOList = new List<MeasurementsDTO>();

            foreach (var measurement in measurementsInfo)
            {
                var measurementDTO = new MeasurementsDTO();

                measurementDTO.Location = measurement.Location;
                measurementDTO.Parameter = measurement.Parameter;
                measurementDTO.Value = measurement.Value;
                measurementDTO.Unit = measurement.Unit;
                measurementDTO.Utc = measurement.Date.Utc;
                measurementDTO.Local = measurement.Date.Local;
                measurementDTO.Latitude = measurement.Coordinates.Latitude;
                measurementDTO.Longitude = measurement.Coordinates.Longitude;

                measurementsDTOList.Add(measurementDTO);
            }

            return measurementsDTOList;
        }
    }
}
