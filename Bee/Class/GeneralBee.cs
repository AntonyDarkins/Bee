using Bee.Interface;

namespace Bee.Class
{
    public class GeneralBee: IGeneralBee
    {
        private int QueenDeadLimit = 20;
        private int WorkerDeadLimit = 70;
        private int DroneDeadLimit = 50;

        public enum BeeTypes
        {
            Worker = 0,
            Drone = 1,
            Queen =2
        };

        public enum StatusEnum
        {
            Alive = 0,
            Dead = 1
        }

        private float health = 100;
        private StatusEnum status = StatusEnum.Alive;

        public StatusEnum Status
        {
            get => status;
            set
            {
                status = value;
            }
        }
        public float Health
        {
            get => health;
            set
            {
                health = value;
            }
        }

        private BeeTypes beeType = BeeTypes.Worker;
        public BeeTypes BeeType
        {
            get => beeType;
            set
            {
                beeType = value;
            }
        }

        public void Damage(int damagePercentage)
        {
            float damagedone = 0;

            if (damagePercentage>100) { damagePercentage = 100; }
            if (damagePercentage < 0) { damagePercentage = 0; }

            if (this.Status == StatusEnum.Alive)
            {
                this.Health = this.Health - damagePercentage;


                switch (this.BeeType)
                {
                    case BeeTypes.Drone:
                        if (Health<DroneDeadLimit) { Status = StatusEnum.Dead; }
                        break;

                    case BeeTypes.Worker:
                        if (Health < WorkerDeadLimit) { Status = StatusEnum.Dead; }
                        break;

                    case BeeTypes.Queen:
                        if (Health < QueenDeadLimit) { Status = StatusEnum.Dead; }
                        break;

                }
            }

        }
    }
}
