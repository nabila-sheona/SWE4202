using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11A
{

public class Doctor : Employee
{
    public string Department { get; set; }
    public string Position { get; set; }
    public List<string> Degrees { get; set; }
    public List<Doctor> CoWorkers { get; set; }
}
}
