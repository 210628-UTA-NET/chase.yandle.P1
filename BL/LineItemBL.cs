using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class LineItemBL : ILineItemBL
    {
        private ILineRepository _repo;
        public LineItemBL(ILineRepository p_repo)
        {
            _repo=p_repo;
        }
        public List<LineItem> GetLineItems(int p_orderID)
        {
                return _repo.GetLineItems(p_orderID);
        }
        public void AddLineItem(LineItem p_line)
        {
             _repo.AddLineItem(p_line);
        }
    }
}