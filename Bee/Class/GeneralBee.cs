//
// Written by A Darkins
// Date 6/8/2020
// Issue : initial
//
// class for generic bee
//


using Bee.Interface;
using Prism.Mvvm;

namespace Bee.Class
{
    public class GeneralBee: BindableBase, IGeneralBee
    {
        //death threshold of each bee
        private int QueenDeadLimit = 20;
        private int WorkerDeadLimit = 70;
        private int DroneDeadLimit = 50;

        //available bee types
        public enum BeeTypes
        {
            Worker = 0,
            Drone = 1,
            Queen =2
        };

        //bee status
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
                SetProperty(ref status, value);
                RaisePropertyChanged(nameof(Status));
            }
        }
        public float Health
        {
            get => health;
            set
            {
                health = value;
                //ensure health valid
                if (health<0) { health = 0; }
                RaisePropertyChanged(nameof(Health));
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
            //validate damage amount
            if (damagePercentage>100) { damagePercentage = 100; }
            if (damagePercentage < 0) { damagePercentage = 0; }

            if (this.Status == StatusEnum.Alive)
            {
                this.Health = this.Health - damagePercentage;

                //check if bee dead
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
