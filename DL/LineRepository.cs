using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class LineRepository : ILineRepository
    {
        private StDbContext _context;
        public LineRepository(StDbContext p_context)
        {  
            _context=p_context;       
        }
        public void AddLineItem(LineItem p_lineitem)
        {
            _context.LineItems.Add(p_lineitem);
            _context.SaveChanges();
        }
        public List<LineItem> GetLineItems(int p_orderID)
        {
            return _context.LineItems.Where(li => li.liOrder.oID == p_orderID).Select(li => li).ToList();
        }
    }
}