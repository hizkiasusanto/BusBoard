using System.Collections.Generic;

namespace BusBoard
{
    public class BusStop
    {
        public string Id { get; set; }
        public string CommonName { get; set; }
        public float Distance { get; set; }

        public List<IncomingBusPrediction> GetIncomingBusPredictions()
        {
            return new TflApi().GetIncomingBusPredictions(this.Id);
        }
    }
}