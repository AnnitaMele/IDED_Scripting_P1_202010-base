namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base((_unitClass == EUnitClass.Dragon || _unitClass == EUnitClass.Orc || _unitClass == EUnitClass.Imp) ? EUnitClass.Villager : _unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;

            if (Potential >= 0.1f)
            {
                Potential = 0.1f;
                
            }

            BaseAtk += (int)(BaseAtk * Potential);
            BaseDef += (int)(BaseDef * Potential);
            
        }



        public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool didchange = false;
            switch (UnitClass)
            {

                case EUnitClass.Squire:
                    if (newClass == EUnitClass.Soldier)
                    {
                        UnitClass = newClass;
                        didchange = true;
                    }
                    break;
                case EUnitClass.Soldier:
                    if (newClass == EUnitClass.Squire)
                    {
                        UnitClass = newClass;
                        didchange = true;
                    }
                    break;
                case EUnitClass.Ranger:
                    if (newClass == EUnitClass.Mage)
                    {
                        UnitClass = newClass;
                        didchange = true;
                    }
                    break;
                case EUnitClass.Mage:
                    if (newClass == EUnitClass.Ranger)
                    {
                        UnitClass = newClass;
                        didchange = true;
                    }
                    break;
                
            }
            return didchange;
        }

        /* public  EUnitClass x (EUnitClass ejemplo){

             if(_unitClass== EUnitClass.Dragon||_unitClass == EUnitClass.Orc||_unitClass== EUnitClass.Imp)
                 {

                     return EUnitClass.Villager;
                  }
             else {

                 return ejemplo;
 }

                 }
                 */
    }
}