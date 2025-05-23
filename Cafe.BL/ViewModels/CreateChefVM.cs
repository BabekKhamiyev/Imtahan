using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.ViewModels;

public class CreateChefVM
{
    public string Name { get; set; }
    public string Field { get; set; }
    public IFormFile ImgFile { get; set; }
}
