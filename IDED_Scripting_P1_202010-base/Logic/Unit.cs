using System;
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
            ModifyByClass();

        }


        public virtual bool Interact(Unit otherUnit)
        {
            int distancerangex = otherUnit.CurrentPosition.x - CurrentPosition.x;
            int distancerangey = otherUnit.CurrentPosition.y - CurrentPosition.y;

            if (AtkRange < Math.Abs(distancerangex) + Math.Abs(distancerangey)) return false;

            bool[,] matrizInteracciones = new bool[,]
            {
                { false,false ,false,false,false,false,false,false},
                { false,true,true,true,true,true,true,true},
                { false,true,true,true,true,true,true,true},
                { true,true,true,true,false,true,true,false},
                {true ,true,true,true,false,true,true,true},
                {true ,true,true,true,true,true,true,false},
                { true,true,true,true,true,true,true,false},
                { true,true,true,true,true,true,true,true}
            };



            return matrizInteracciones[(int)UnitClass, (int)otherUnit.UnitClass];
        }

        //public virtual bool Interact(Prop prop) => false;
        public virtual bool Interact(Prop prop)
        {
            if(UnitClass == EUnitClass.Villager)
            {
                return true;
            }
            return false;
        }

        // public bool Move(Position targetPosition) => false;
        public bool Move(Position targetPosition)
        {
            int movex = targetPosition.x - CurrentPosition.x;
            int movey = targetPosition.y - CurrentPosition.y;

            if (MoveRange >= Math.Abs(movex) + Math.Abs(movey))
            {
                CurrentPosition = targetPosition;
                return true;
            }

            return false;
        }

        public void ModifyByClass()
        {
            switch (UnitClass)
            {

                case EUnitClass.Villager:
                    AddPorcent(0, 0, 0);
                    AtkRange = 0;

                    break;

                case EUnitClass.Squire:
                    AddPorcent(0.02f, 0.01f, 0);
                    AtkRange = 1;

                    break;

                case EUnitClass.Soldier:
                    AddPorcent(0.03f, 0.02f, 0.01f);
                    AtkRange = 1;

                    break;

                case EUnitClass.Ranger:
                    AddPorcent(0.01f, 0, 0.03f);
                    AtkRange = 3;

                    break;

                case EUnitClass.Mage:
                    AddPorcent(0.03f, 0.01f, -0.01f);
                    AtkRange = 3;

                    break;

                case EUnitClass.Imp:
                    AddPorcent(0.01f, 0, 0);
                    AtkRange = 1;

                    break;

                case EUnitClass.Orc:
                    AddPorcent(0.04f, 0.02f, -0.02f);
                    AtkRange = 1;

                    break;

                case EUnitClass.Dragon:
                    AddPorcent(0.05f, 0.03f, 0.02f);
                    AtkRange = 5;

                    break;
                default:
                    break;
            }
        }
        public void AddPorcent(float _atkAdd, float _defAdd, float _speedAdd)
        {
            //Bloqueo
            _atkAdd = ((_atkAdd > 1) ? (1) : ((_atkAdd < -1) ? (-1) : (_atkAdd)));
            _defAdd = _defAdd > 1 ? 1 : _defAdd < -1 ? -1 : _defAdd;
            _speedAdd = _speedAdd > 1 ? 1 : _speedAdd < -1 ? -1 : _speedAdd;


            BaseAtkAdd = _atkAdd;
            BaseDefAdd = _defAdd;
            BaseSpdAdd = _speedAdd;

            BaseAtk += (int)(BaseAtkAdd * 255);
            BaseDef += (int)(BaseDefAdd * 255);
            BaseSpd += (int)(BaseSpdAdd * 255);

            BaseAtk = BaseAtk > 255 ? 255 : BaseAtk < 0 ? 0 : BaseAtk;
            BaseDef = BaseDef > 255 ? 255 : BaseDef < 0 ? 0 : BaseDef;
            BaseSpd = BaseSpd > 255 ? 255 : BaseSpd < 0 ? 0 : BaseSpd;


        }

    }
}