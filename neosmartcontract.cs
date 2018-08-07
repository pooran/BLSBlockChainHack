using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework;
using System;

namespace Neo.SmartContract
{
    public class MapExample : Framework.SmartContract
    {
        [Serializable]
        public class Request
        {
            public string PId;
            public string UId;
            public string Bids;
        }

        [Serializable]
        public class Bid
        {
            public string PId;
            public string BidId;
            public bool IsAccepted;
            public bool IsPickedUp;
        }
        public static void Main(string operation, params object[] args)
        {
             if (operation == "requestbids")
            {
                RequestBids(new Request() { PId = (string)args[0], UId = (string)args[1], Bids = (string)args[2] });
            }
            else if (operation == "submitbid")
            {
                SubmitBid(new Bid() { PId = (string)args[0], BidId = (string)args[1], IsAccepted = (bool)args[2], IsPickedUp = (bool)args[3] });
            }
            else if (operation == "acceptbid")
            {
                AcceptBid(new Bid() { PId = (string)args[0], BidId = (string)args[1], IsAccepted = (bool)args[2], IsPickedUp = (bool)args[3] });
            }
            else if (operation == "pickupmedicine")
            {
                PickUpMedicine(new Bid() { PId = (string)args[0], BidId = (string)args[1], IsAccepted = (bool)args[2], IsPickedUp = (bool)args[3] });
            }
            Runtime.Notify("hello");
        }
        public static void RequestBids(Request request)
        {
            Storage.Put(Storage.CurrentContext, "PId" + request.PId, request.Serialize());
            Request test = (Request)Storage.Get(Storage.CurrentContext, "PId" + request.PId).Deserialize();
            Runtime.Notify(request.PId, request.UId, request.Bids);
        }
        public static void SubmitBid(Bid bid)
        {
            Request request = (Request)Storage.Get(Storage.CurrentContext, "PId" + bid.PId).Deserialize();
            Storage.Put(Storage.CurrentContext, "BidId" + bid.BidId, bid.Serialize());
            request.Bids = request.Bids + bid.BidId + ",";
            Storage.Put(Storage.CurrentContext, "PId" + request.PId, request.Serialize());
            Runtime.Notify(request.PId, request.UId, request.Bids);
        }
        public static void AcceptBid(Bid bid)
        {
            Bid abid = (Bid)Storage.Get(Storage.CurrentContext, "BidId" + bid.BidId).Deserialize();
            abid.IsAccepted = true;
            Storage.Put(Storage.CurrentContext, "BidId" + abid.BidId, abid.Serialize());
            Runtime.Notify(abid.PId, abid.BidId, abid.IsAccepted);
        }
        public static void PickUpMedicine(Bid bid)
        {
            Bid abid = (Bid)Storage.Get(Storage.CurrentContext, "BidId" + bid.BidId).Deserialize();
            abid.IsPickedUp = true;
            Storage.Put(Storage.CurrentContext, "BidId" + abid.BidId, abid.Serialize());
            Runtime.Notify(abid.PId, abid.BidId, abid.IsPickedUp);
        }
    }
}