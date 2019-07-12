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

                measurementDTO.location = measurement.location;
                measurementDTO.parameter = measurement.parameter;
                measurementDTO.value = measurement.value;
                measurementDTO.unit = measurement.unit;
                measurementDTO.utc = measurement.date.utc.ToString();
                measurementDTO.local = measurement.date.local.ToString();
                measurementDTO.latitude = measurement.coordinates.latitude;
                measurementDTO.longitude = measurement.coordinates.longitude;

                measurementsDTOList.Add(measurementDTO);
            }

            return measurementsDTOList;
        }
    }
}
