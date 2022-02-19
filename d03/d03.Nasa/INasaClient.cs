using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa
{
    public interface INasaClient<in TIn, out TOut>
    {
        public async TOut GetAsync(TIn input)
        {
            
        }
    }
}
