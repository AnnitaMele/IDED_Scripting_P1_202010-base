namespace IDED_Scripting_P1_202010_base.Logic
{
    public enum EUnitClass
    {
        Villager,
        Squire,
        Soldier,
        Ranger,
        Mage,
        Imp,
        Orc,
        Dragon
    }

    public class TipoUnit : Unit
    {
        public EUnitClass unitType { get; protected set; }

        public EUnitClass(EUnitClass _unitType)
        {
            unitType = _unitType;
        }

        public TipoUnit(int _atkAdd, int _defAdd, int _spdAdd, int _moveRangeAdd)
        {

        }

        public class Villager() 


    }


}