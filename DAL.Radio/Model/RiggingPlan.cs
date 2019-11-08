using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class RiggingPlan
    {
        public RiggingPlan()
        {
            Sites = new List<Site>();
        }

        [Key]
        public int RiggingPlanId { get; set; }
        public string RiggingPlanNotes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
   


    //public class RiggingPlanClassDefinition
    //{
    //    public RiggingPlanClassDefinition()
    //    {

    //    }

    //    public int RiggingPlanClassDefinitionId { get; set; }
    //    public string RiggingPlanClassDefinitionName { get; set; }
    //}

    //public class RiggingPlanClassType
    //{
    //    public RiggingPlanClassType()
    //    {

    //    }

    //    public int RiggingPlanClassTypeId { get; set; }
    //    public string RiggingPlanClassTypeName { get; set; }
    //    public string RiggingPlanClassTypeCategory { get; set; }
    //}

    ////Inherits from Construction Company or Owner
    //public class GeneralScopeOfWork : RiggingPlan
    //{
    //    //
    //    public bool InstallNewStructure { get; set; }
    //    public bool DeconstructAndOrDemoExistingStructure { get; set; }
    //    public bool InstallNewTowerFoundation { get; set; }
    //    public bool ModifyExistingTowerFoundation { get; set; }
    //    public bool InstallAntennasLinesAndOrMounts { get; set; }
    //    public bool RemoveAntennaLinesAndOrMounts { get; set; }
    //    public bool PerformGeneralTowerMaint { get; set; }
    //    public bool InstallTowerReinforcement { get; set; }
    //    public bool PerformCuttingAndOrWelding { get; set; }
    //    public bool ReplaceStructuralMembers { get; set; }
    //    public bool ReplaceStructuralComponents { get; set; } //Bolts Stiffeners etc..
    //    public bool ReplaceGuyCables { get; set; }
    //    public string Other { get; set; }
    //    public bool TowerPlumbAndOrGuyReTransforming { get; set; }
    //}

    //public class MaximumGrossLiftLoad : RiggingPlan
    //{
    //    public int WeightLoadId { get; set; }
    //    public string WeightLoadConditionMinimum { get; set; }
    //    public string WeightLoadConditionMaximum { get; set; }
    //    public bool IsSelected { get; set; }
    //}

    //public class StructureData : RiggingPlan
    //{
    //    public int StructureDataId { get; set; }
    //    public string Manufacturer { get; set; }
    //    public string FaceWidthAtBase { get; set; }
    //    public string StructureDataHeight { get; set; }
    //    public string TypicalSectionLength { get; set; }

    //    public List<string> StructureDataType { get; set; }
    //    public List<string> Guyed { get; set; }

    //}

    //public class ConstructionDuration : RiggingPlan
    //{
    //    /// <summary>
    //    /// Yellow background
    //    /// </summary>
    //    public int ConstructionDuractionId { get; set; }

    //    /// <summary>
    //    /// Blue Blackground - Title
    //    /// </summary>
    //    public string SetConstructionDuration { get; set; }

    //    /// <summary>
    //    /// Yellow background
    //    /// </summary>
    //    public DateTime PlannedMobilizationDate { get; set; }

    //    /// <summary>
    //    /// Yellow background
    //    /// </summary>
    //    public DateTime PlannedDemobilizationDate { get; set; }

    //    /// <summary>
    //    /// Green background
    //    /// </summary>
    //    public double Days { get; set; }
    //}

    //public class PrimaryConstructionEquipment : RiggingPlan
    //{
    //    public int PrimaryConstEquipId { get; set; }
    //    public string PrimaryConstEquipName { get; set; }
    //    public string PrimaryConstEquipCategory { get; set; }
    //    public string PrimaryConstEquipDescription { get; set; }
    //}

    //public class LiftingSystemData : RiggingPlan
    //{
    //    public int LiftingSystemDataId { get; set; }
    //    public string LiftingSystemName { get; set; }
    //    public string LiftingSystemDescription { get; set; }
    //    public string LiftingSystemCategory { get; set; }
    //}

    //public class LiftingAndControlLineData : RiggingPlan
    //{
    //    public int LiftingAndControlLineDataId { get; set;}
    //    public string LiftingAndControlLineDataCategory { get; set; }
    //    public string LiftingAndControlLineDataDescription { get; set; }
    //    public string LiftingAndControlLineDataSizeGrade { get; set; }
    //    //Maximum Load Position angle
    //    //MaximumTagAngle
    //}

    //public class LoadTestingAndVerification : RiggingPlan
    //{
    //    public int LoadTestingAndVerificationId { get; set; }
    //    public string LoadTestingAndVerificationName { get; set; }
    //}

    //public class TemporaryBracing : RiggingPlan
    //{
    //    public int TemporaryBracingId { get; set; }
    //    public string TemporaryBracingName { get; set; }
    //    public string TemporaryBracingCategory { get; set; }
    //}

    //public class FinalSignOffs : RiggingPlan
    //{
    //    public int FinalSignOffsId { get; set; }
    //    public string FinalSignOffsName { get; set; }
    //    //Add image for signature
    //}
    //public class CraneInformation : RiggingPlan
    //{
    //   public int CraneInformationId { get; set; }
    //    public string CraneInformationResponsiblePerson { get; set; }
    //    public string CraneInformationCategory { get; set; }
    //    public string CraneInformationCompany { get; set; }
    //}

    //public class CraneData : CraneInformation
    //{
    //    public int CraneDataId { get; set; }
    //    public string CraneDataCompany { get; set; }
    //    public string CraneDataModelSizeId { get; set; }
    //    public string CraneDataModelType { get; set; }
    //    public string CraneDataCraneCapacity { get; set; }
    //}

    //public class MaximumCraneGrossLiftLoad : CraneInformation
    //{
    //    public int MaximumCraneGrossLiftLoadId { get; set; }
    //    public string MaximumCraneGrossLiftLoadName { get; set; }
    //    public string MaximumCraneGrossLiftLoadCategory { get; set; }
    //    public string MaximumCraneGrossLiftLoadDescription { get; set; }
    //}

    //public class CraneLiftData : CraneInformation
    //{
    //    public int CraneLiftDataId { get; set; }
    //    public string CraneLiftDataName { get; set; }
    //    public string CraneLiftDataCategory { get; set; }
    //    public string CraneLiftDataDescription { get; set; }
    //}

    //public class CraneSpecialConditions : CraneInformation
    //{
    //    public int CraneSpecialConditionsId { get; set; }
    //    public string CraneSpecialConditionsName { get; set; }
    //    public string CraneSpecialConditionsCategory { get; set; }
    //    public string CraneSpecialConditionsDescription { get; set; }
    //}

    //public class CraneOperatorSignOff : CraneInformation 
    //{
    //    public int CraneOperatorSignOffId { get; set; }
    //    //Image Signature -- 
    //    public DateTime CraneOperatorSignedDateTime { get; set; }

    //    public string CraneOperatorNotes { get; set; }
    //}

    //public class RiggingPlanCheckList : RiggingPlan
    //{
    //    public int RiggingPlanCheckListId { get; set; }
    //    public string RiggingPlanCheckListName { get; set; }
    //    public string RiggingPlanCheckListCategory { get; set; }
    //    public string RiggingPlanCheckListDescription { get; set; }
    //    public string RiggingPlanCheckListDetails { get; set; }
    //}
}
