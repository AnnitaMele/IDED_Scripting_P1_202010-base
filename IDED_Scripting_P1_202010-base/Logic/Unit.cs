namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    Attack = 0;
                    Defense = 0;
                    Speed = 0;


                    break;

                case EUnitClass.Squire:
                    Attack = 2;
                    Defense = 1;
                    Speed = 0;
                    break;

                case EUnitClass.Soldier:
                    Attack = 3;
                    Defense = 2;
                    Speed = 1;
                    break;

                case EUnitClass.Ranger:
                    Attack = 1;
                    Defense = 0;
                    Speed = 3;
                    break;

                case EUnitClass.Orc:
                    Attack = 4;
                    Defense = 2;
                    Speed = -2;
                    break;

                case EUnitClass.Mage:
                    Attack = 3;
                    Defense = 1;
                    Speed = -1;
                    break;

                case EUnitClass.Imp:
                    Attack = 1;
                    Defense = 0;
                    Speed = 0;
                    break;

                case EUnitClass.Dragon:
                    Attack = 5;
                    Defense = 3;
                    Speed = 2;
                    break;
            }

            

        }

        
        

        public virtual bool Interact(Unit otherUnit)
        {
            return false;
        }

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position targetPosition) => false;
    }
}