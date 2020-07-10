using System.Collections.Generic;

namespace BusBoard.Api
{
    public class StopWithArrivals
    {
        public BusStop BusStop { get; set; }

        public List<IncomingBusPrediction> IncomingBusPredictions
        {
            get;
            set;
        }

        public StopWithArrivals(BusStop busStop)
        {
            this.BusStop = busStop;
            this.IncomingBusPredictions = new TflApiHandler().GetIncomingBusPredictions(busStop.Id);
        }
    }
}