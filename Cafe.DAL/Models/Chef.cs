using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.DAL.Models;

public class Chef:BaseModel
{
    public string Name { get; set; }
    public string Field { get; set; }
    public string ImgUrl { get; set; }
}
