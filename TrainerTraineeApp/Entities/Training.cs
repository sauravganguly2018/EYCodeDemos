namespace TrainerTraineeApp.Entities
{
    public class Training
    {
        public Trainer Trainer { get; set; }
        public List<Trainee> Trainees { get; set; } =new List<Trainee>();
        public Course Course { get; set; }  

        public string GetTrainingOrgName()
        {
            // return org name
            return Trainer.TheOrg.OrgName;
        }

        public int GetTraineesCount()
        {
            // return no. trainees count
            return Trainees.Count;
        }

        int durationTotal = 0;

        // for each module in a course
        public int GetTrainingDuration()
        {
            foreach (Module module in Course.Modules)
            {
                // for each unit in a module
                foreach (Unit unit in module.Units)
                {
                    durationTotal += unit.Duration;
                }
            }
            return durationTotal;
        }
    }
}