using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  [RoutePrefix("almacen")]
  public class AlmacenController : CrudController<AlmacenDto>
  {
    public AlmacenController(ICrudService<AlmacenDto> service) : base(service)
    {
    }
  }
}
