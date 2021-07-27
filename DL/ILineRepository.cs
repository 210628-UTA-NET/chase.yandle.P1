using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public interface ILineRepository
    {
        public void AddLineItem(LineItem p_lineitem);
        public List<LineItem> GetLineItems(int p_orderID);
    }
}