using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class GoalDefinition
    {
        public int Id { get; set; }
        public Goal Goal { get; set; }
        public Gender Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int Calories { get; set; }

    }
}
