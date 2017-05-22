using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  [RoutePrefix("articulo")]
  public class ArticuloController : CrudController<ArticuloDto>
  {
    public ArticuloController(ICrudService<ArticuloDto> service) : base(service)
    {
    }
  }
}
