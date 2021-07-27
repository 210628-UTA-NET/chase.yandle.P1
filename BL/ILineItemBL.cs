using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface ILineItemBL
    {
        public List<LineItem> GetLineItems(int p_orderID);
        public void AddLineItem(LineItem p_line);
    }
}