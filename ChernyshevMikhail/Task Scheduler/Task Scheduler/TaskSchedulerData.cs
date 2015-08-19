using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Scheduler
{
    public class TaskSchedulerData 
    {
        public TaskSchedulerData()
        {
            Tasks = new List<TaskData>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public Gender Gender { get; set; }

        public List<TaskData> Tasks { get; set; }

        public byte[] Photo { get; set; }
    }
    public class TaskData
    {
        public DateTime Date { get; set; }
        public string TextofTask { get; set; }
        public string Priority { get; set; }

        public override string ToString()
        {
            if (TextofTask.Length <= 50)
                return string.Format("К: {0}, Выполнить: {1}, Приоритет:{2} ", Date, TextofTask, Priority);
            else
            {
                var S = TextofTask.Substring(0, 47);
                return string.Format("К: {0}, Выполнить: {1}..., Приоритет:{2} ", Date, TextofTask, Priority);
            }
        }
    }
    public enum Gender
    {
        Male,
        Female,
        NoSelected
    }

}
