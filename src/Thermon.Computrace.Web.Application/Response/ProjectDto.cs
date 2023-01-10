using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Response
{
    public class BillOfMaterialsEntry
    {
        public Guid BillOfMaterialsEntryID { get; set; }
        public Guid SegmentID { get; set; }
        public int ItemNumber { get; set; }
        public string PartNumber { get; set; }
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        public string DescriptionShort { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public Nullable<int> CatalogPartID { get; set; }
        public Nullable<int> CablePartID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public Segment Segment { get; set; } // DERIVED
    }

    public class Circuit
    {
        public Guid CircuitID { get; set; }
        public Guid ProjectID { get; set; }
        public string CircuitName { get; set; }
        public string CustomerCircuitNumber { get; set; }
        public int CircuitOrder { get; set; }
        public int AnalysisTypeID { get; set; }
        public int CircuitConfigurationID { get; set; }
        public double Voltage { get; set; }
        public int CircuitBreakerSize { get; set; }
        public int CircuitBreakerTypeID { get; set; }
        public bool AllowSpiraling { get; set; }
        public bool AllHeaterSetsOnSingleBreaker { get; set; }
        public int TemperatureControlTypeID { get; set; }
        public Nullable<int> AmbientSensingSetpoint { get; set; }
        public Nullable<int> ControlLimitedSetpoint { get; set; }
        public int MaintenanceTemp { get; set; }
        public Nullable<int> ElectricalStandardsClassID { get; set; }
        public Nullable<int> ElectricalStandardsDivisionOrZoneID { get; set; }
        public Nullable<int> ElectricalStandardsGroupID { get; set; }
        public Nullable<int> TClassID { get; set; }
        public Nullable<int> AutoignitionTemp { get; set; }
        public Nullable<int> HeatUpInitialTemp { get; set; }
        public Nullable<int> HeatUpFinalTemp { get; set; }
        public Nullable<int> CoolDownInitialTemp { get; set; }
        public Nullable<int> CoolDownFinalTemp { get; set; }
        public Nullable<Guid> ProcessFluidID { get; set; }
        public bool IsProjectDefault { get; set; }
        public int ExtraWireFieldFactor { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public DateTime LastModified { get; set; }
        public Nullable<Guid> ParentCircuitID { get; set; }
        public Nullable<int> OperatingTemp { get; set; }
        public Nullable<decimal> DesiredTimeToTemp { get; set; }
        public bool IsTemplate { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public AnalysisType AnalysisType { get; set; } // DERIVED
        public CircuitConfiguration CircuitConfiguration { get; set; } // DERIVED
        public CircuitBreakerType CircuitBreakerType { get; set; } // DERIVED
        public TemperatureControlType TemperatureControlType { get; set; } // DERIVED
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public ElectricalStandardsDivisionOrZone ElectricalStandardsDivisionOrZone { get; set; } // DERIVED
        public ElectricalStandardsGroup ElectricalStandardsGroup { get; set; } // DERIVED
        public TClass TClass { get; set; } // DERIVED
        public ProcessFluid ProcessFluid { get; set; } // DERIVED
        public Circuit ParentCircuit { get; set; } // DERIVED
        public CircuitOwner CircuitOwner { get; set; }
        public List<CircuitEquipmentCoordinates> CircuitEquipmentCoordinatesList { get; set; }
        public List<CircuitOwner> CircuitOwners { get; set; }
        public List<CircuitReference> CircuitReferences { get; set; }
        public List<CircuitReferenceDrawing> CircuitReferenceDrawings { get; set; }
        public List<Connection> Connections { get; set; }
        public List<DesignCircuit> DesignCircuits { get; set; }
        public List<MIQCircuitOverride> MIQCircuitOverrides { get; set; }
    }

    public class CircuitBreakerType
    {
        public int CircuitBreakerTypeID { get; set; }
        public string CircuitBreakerTypeName { get; set; }
        public List<Circuit> Circuits { get; set; }
    }

    public class CircuitReference
    {
        public Guid CircuitReferenceID { get; set; }
        public Guid CircuitID { get; set; }
        public string ReferenceNumber { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
    }

    public class CircuitConfiguration
    {
        public int CircuitConfigurationID { get; set; }
        public string CircuitConfigurationName { get; set; }
        public List<Circuit> Circuits { get; set; }
    }

    public class CircuitEquipmentCoordinates
    {
        public Guid CircuitEquipmentCoordinatesID { get; set; }
        public Guid CircuitID { get; set; }
        public int CircuitEquipmentCoordinatesTypeID { get; set; }
        public string HeaterNumber { get; set; }
        public string East { get; set; }
        public string North { get; set; }
        public string Elevation { get; set; }
        public string UserTag { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
        public CircuitEquipmentCoordinatesType CircuitEquipmentCoordinatesType { get; set; } // DERIVED
    }

    public class CircuitEquipmentCoordinatesType
    {
        public int CircuitEquipmentCoordinatesTypeID { get; set; }
        public string EquipmentCoordinatesTypeName { get; set; }
        public List<CircuitEquipmentCoordinates> CircuitEquipmentCoordinatesList { get; set; }
    }

    public class AnalysisType
    {
        public int AnalysisTypeID { get; set; }
        public string AnalysisTypeName { get; set; }
        public bool IsActive { get; set; }
        public List<Circuit> Circuits { get; set; }
    }

    public class CircuitOwner
    {
        public Guid CircuitID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public Nullable<bool> IsConflict { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class Connection
    {
        public Guid ConnectionID { get; set; }
        public Guid CircuitID { get; set; }
        public string ConnectionName { get; set; }
        public bool UserSpecifiedTraceRatio { get; set; }
        public Nullable<int> NumberOfHeaterSets { get; set; }
        public Nullable<int> TraceRatioPerHeaterSet { get; set; }
        public bool IsParallelHeater { get; set; }
        public Nullable<int> CableFamilyID { get; set; }
        public bool IsCableFamilyUserSelected { get; set; }
        public bool UseSameHeaterForAllSegments { get; set; }
        public int ConnectionOrder { get; set; }
        public int InstallationMethodID { get; set; }
        public int MaxExposureTemp { get; set; }
        public int MaxProductTemp { get; set; }
        public bool ForceTESHColdLeads { get; set; }
        public Nullable<int> MaxIntermittentExposure { get; set; }
        public Nullable<bool> IsChannelAboveCenterline { get; set; }
        public int MinAmbientTemp { get; set; }
        public int MaxAmbientTemp { get; set; }
        public Nullable<int> StartUpAmbientTemp { get; set; }
        public Nullable<int> Wind { get; set; }
        public int ChemicalExposureID { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
        public CableFamily CableFamily { get; set; } // DERIVED
        public InstallationMethod InstallationMethod { get; set; } // DERIVED
        public ChemicalExposure ChemicalExposure { get; set; } // DERIVED
        public List<ConnectionComponent> ConnectionComponents { get; set; }
        public List<ConnectionDefaultComponent> ConnectionDefaultComponents { get; set; }
        public List<ConnectionDefaultMIQSpecification> ConnectionDefaultMIQSpecifications { get; set; }
        public List<ConnectionMIQSpecification> ConnectionMIQSpecifications { get; set; }
        public List<DesignConnection> DesignConnections { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class ChemicalExposure
    {
        public int ChemicalExposureID { get; set; }
        public string ChemicalExposureName { get; set; }
        public List<Connection> Connections { get; set; }
    }

    public class InstallationMethod
    {
        public int InstallationMethodID { get; set; }
        public string InstallationMethodName { get; set; }
        public List<Connection> Connections { get; set; }
    }

    public class ConnectionComponent
    {
        public Guid ConnectionID { get; set; }
        public bool IsPowerKitOverridden { get; set; }
        public bool IsSpliceKitOverridden { get; set; }
        public bool IsTeeKitOverridden { get; set; }
        public bool IsEndTerminationOverridden { get; set; }
        public bool IsLocalControlOverridden { get; set; }
        public bool IsSensorOverridden { get; set; }
        public bool IsPowerKitApplicable { get; set; }
        public bool IsSpliceKitApplicable { get; set; }
        public bool IsTeeKitApplicable { get; set; }
        public bool IsEndSealKitApplicable { get; set; }
        public bool IsLocalControlApplicable { get; set; }
        public string LocalControlTag { get; set; }
        public string SensorTag1 { get; set; }
        public string SensorTag2 { get; set; }
        public Nullable<int> DesignControllerSelectionResultID { get; set; }
        public Nullable<int> LocalControlTypeSelectionID { get; set; }
        public Nullable<bool> IsUnderTheInsulationEndSealIncluded { get; set; }
        public bool UseCustomProvidedComponents { get; set; }
        public Nullable<bool> ControllerAsPowerComponent { get; set; }
        public string LocalControlTag2 { get; set; }
        public Nullable<Guid> SensorID { get; set; }
        public Nullable<Guid> LocalControlID { get; set; }
        public Nullable<Guid> PowerComponentCatalogPartID { get; set; }
        public Nullable<Guid> SpliceComponentCatalogPartID { get; set; }
        public Nullable<Guid> TeeComponentCatalogPartID { get; set; }
        public Nullable<Guid> EndComponentCatalogPartID { get; set; }
        public Connection Connection { get; set; } // DERIVED
        public DesignControllerSelectionResult DesignControllerSelectionResult { get; set; } // DERIVED
        public ComponentControlTypeSelection LocalControlTypeSelection { get; set; } // DERIVED
        public SelectableCatalogPart Sensor { get; set; } // DERIVED
        public SelectableCatalogPart LocalControl { get; set; } // DERIVED
        public SelectableCatalogPart PowerComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart SpliceComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart TeeComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart EndComponentCatalogPart { get; set; } // DERIVED
        public List<SelectableCatalogPart> SelectableCatalogParts { get; set; } // DERIVED
        public List<ConnectionComponentTag> ConnectionComponentTags { get; set; }
    }

    public class DesignControllerSelectionResult
    {
        public int DesignControllerSelectionResultID { get; set; }
        public string ResultDescription { get; set; }
        public List<ConnectionComponent> ConnectionComponents { get; set; }
    }

    public class ConnectionComponentTag
    {
        public Guid ConnectionComponentTagID { get; set; }
        public Guid ConnectionComponentID { get; set; }
        public string Tag { get; set; }
        public int TagNumber { get; set; }
        public Nullable<int> ComponentTypeID { get; set; }
        public ConnectionComponent ConnectionComponent { get; set; } // DERIVED
        public ComponentType ComponentType { get; set; } // DERIVED
    }

    public class ConnectionDefaultComponent
    {
        public Guid ConnectionID { get; set; }
        public Guid DefaultComponentID { get; set; }
        public Connection Connection { get; set; } // DERIVED
        public DefaultComponent DefaultComponent { get; set; } // DERIVED
    }

    public class DesignCircuit
    {
        public Guid CircuitID { get; set; }
        public Nullable<DateTime> LastDesigned { get; set; }
        public int DesignStatusID { get; set; }
        public int DesignErrorID { get; set; }
        public Nullable<Guid> DesignExceptionLogEntryID { get; set; }
        public string TraceOutput { get; set; }
        public double CircuitOperatingLoad { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
        public DesignStatus DesignStatus { get; set; } // DERIVED
        public DesignError DesignError { get; set; } // DERIVED
        public LogEntry DesignExceptionLogEntry { get; set; } // DERIVED
        public List<DesignCircuitBreaker> DesignCircuitBreakers { get; set; }
    }

    public class LogEntry
    {
        public Guid LogEntryID { get; set; }
        public int LogEntryTypeID { get; set; }
        public string Message { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string TraceOutput { get; set; }
        public LogEntryType LogEntryType { get; set; } // DERIVED
        public List<DesignCircuit> DesignCircuits { get; set; }
    }

    public class LogEntryType
    {
        public int LogEntryTypeID { get; set; }
        public string LogEntryTypeName { get; set; }
        public string LogEntryTypeDescription { get; set; }
        public int SeverityRank { get; set; }
        public List<LogEntry> LogEntries { get; set; }
    }

    public class DesignError
    {
        public int DesignErrorID { get; set; }
        public string ErrorName { get; set; }
        public string ErrorDescription { get; set; }
        public string DeveloperNotes { get; set; }
        public List<DesignCircuit> DesignCircuits { get; set; }
        public List<DesignConnection> DesignConnections { get; set; }
        public List<DesignErrorSuggestedSolutionEntry> DesignErrorSuggestedSolutionEntries { get; set; }
        public List<DesignSegment> DesignSegments { get; set; }
    }

    public class DesignErrorSuggestedSolutionEntry
    {
        public int DesignErrorSuggestedSolutionEntryID { get; set; }
        public int DesignErrorSuggestedSolutionID { get; set; }
        public int DesignErrorID { get; set; }
        public int Order { get; set; }
        public bool IsParallelHeater { get; set; }
        public DesignErrorSuggestedSolution DesignErrorSuggestedSolution { get; set; } // DERIVED
        public DesignError DesignError { get; set; } // DERIVED
    }

    public class DesignErrorSuggestedSolution
    {
        public int DesignErrorSuggestedSolutionID { get; set; }
        public string DesignErrorSuggestedSolutionText { get; set; }
        public List<DesignErrorSuggestedSolutionEntry> DesignErrorSuggestedSolutionEntries { get; set; }
    }

    public class DesignStatus
    {
        public int DesignStatusID { get; set; }
        public string StatusName { get; set; }
        public List<DesignCircuit> DesignCircuits { get; set; }
    }

    public class DesignConnection
    {
        public Guid ConnectionID { get; set; }
        public int DesignErrorID { get; set; }
        public int NumberOfPasses { get; set; }
        public double OperatingCurrent { get; set; }
        public double MaximumCurrent { get; set; }
        public Connection Connection { get; set; } // DERIVED
        public DesignError DesignError { get; set; } // DERIVED
        public List<DesignHeaterSet> DesignHeaterSets { get; set; }
    }

    public class DesignHeaterSet
    {
        public Guid DesignHeaterSetID { get; set; }
        public Guid DesignConnectionID { get; set; }
        public string HeaterSetName { get; set; }
        public double Length { get; set; }
        public double OperatingWatts { get; set; }
        public double OperatingCurrent { get; set; }
        public double MaximumCurrent { get; set; }
        public Nullable<double> CurrentBOW { get; set; }
        public Nullable<double> CurrentTOW { get; set; }
        public DesignConnection DesignConnection { get; set; } // DERIVED
        public List<DesignHeaterSetBreaker> DesignHeaterSetBreakers { get; set; }
        public List<DesignMIQHeater> DesignMIQHeaters { get; set; }
        public List<DesignSegmentHeaterSet> DesignSegmentHeaterSets { get; set; }
    }

    public class DesignSegment
    {
        public Guid SegmentID { get; set; }
        public int DesignErrorID { get; set; }
        public double HeatLoss { get; set; }
        public double TotalCable { get; set; }
        public double ValveAllowance { get; set; }
        public double SupportAllowance { get; set; }
        public double FlangeAllowance { get; set; }
        public double PumpAllowance { get; set; }
        public double MiscellaneousAllowance { get; set; }
        public double TerminationAllowance { get; set; }
        public double AdditionalPowerAllowance { get; set; }
        public Nullable<int> SelectedCableID { get; set; }
        public double PowerOutput { get; set; }
        public double SpiralRatio { get; set; }
        public int TraceRatioPerHeaterSet { get; set; }
        public int NumberOfHeaterSets { get; set; }
        public double OperatingCableTemp { get; set; }
        public Nullable<double> OperatingCableTempHigh { get; set; }
        public double OperatingPipeTemp { get; set; }
        public Nullable<double> OperatingPipeTempHigh { get; set; }
        public double MaxPipeTemp { get; set; }
        public double MaxCableTemp { get; set; }
        public Nullable<Guid> ChosenInsulationDimensionID { get; set; }
        public double PipeTouchingInsulationMeanTemp { get; set; }
        public double PipeTouchingInsulationKValue { get; set; }
        public Nullable<double> NonPipeTouchingInsulationMeanTemp { get; set; }
        public Nullable<double> NonPipeTouchingInsulationKValue { get; set; }
        public Nullable<bool> CanUsePowerOutputLimitedTerminator { get; set; }
        public bool HasDesignTemperatureValues { get; set; }
        public double ActualHeatLoss { get; set; }
        public double ConstructionAllowance { get; set; }
        public Segment Segment { get; set; } // DERIVED
        public DesignError DesignError { get; set; } // DERIVED
        public Cable SelectedCable { get; set; } // DERIVED
        public InsulationDimension ChosenInsulationDimension { get; set; } // DERIVED
        public List<DesignSegmentFormatArgument> DesignSegmentFormatArguments { get; set; }
        public List<DesignSegmentHeaterSet> DesignSegmentHeaterSets { get; set; }
        public List<DesignSegmentHeatUpCoolDownPoint> DesignSegmentHeatUpCoolDownPoints { get; set; }
        public List<DesignSegmentMIQHeater> DesignSegmentMIQHeaters { get; set; }
    }

    public class DesignSegmentHeatUpCoolDownPoint
    {
        public Guid DesignSegmentHeatUpCoolDownPointID { get; set; }
        public Guid DesignSegmentID { get; set; }
        public double Temperature { get; set; }
        public double Time { get; set; }
        public bool IsPhaseChangePoint { get; set; }
        public DesignSegment DesignSegment { get; set; } // DERIVED
    }

    public class DesignSegmentFormatArgument
    {
        public Guid DesignSegmentFormatArgumentID { get; set; }
        public Guid DesignSegmentID { get; set; }
        public int FormatPosition { get; set; }
        public string FormatArgument { get; set; }
        public DesignSegment DesignSegment { get; set; } // DERIVED
    }

    public class DesignSegmentHeaterSet
    {
        public Guid DesignSegmentHeaterSetID { get; set; }
        public Guid DesignSegmentID { get; set; }
        public Guid DesignHeaterSetID { get; set; }
        public DesignSegment DesignSegment { get; set; } // DERIVED
        public DesignHeaterSet DesignHeaterSet { get; set; } // DERIVED
    }



    public class ProjectOwner
    {
        public Guid ProjectID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public Nullable<DateTime> ClientLastSynchronizedDate { get; set; }
        public Nullable<bool> IsDeactivated { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class HeatSink
    {
        public Guid HeatSinkID { get; set; }
        public string HeatSinkName { get; set; }
        public string Description { get; set; }
        public bool UserDefined { get; set; }
        public int HeatSinkTypeID { get; set; }
        public int HeatSinkCableCalculationID { get; set; }
        public bool IsNotchedSupport { get; set; }
        public DateTime LastModified { get; set; }
        public int UnitID { get; set; }
        public string DescriptionShort { get; set; }
        string DisplayName { get; set; }
        public Nullable<Guid> ParentHeatSinkID { get; set; }
        public bool Promoted { get; set; }
        public Nullable<Guid> ProjectID { get; set; }
        public HeatSinkType HeatSinkType { get; set; } // DERIVED
        public HeatSinkCableCalculation HeatSinkCableCalculation { get; set; } // DERIVED
        public Unit Unit { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
        public List<HeatSinkOwner> HeatSinkOwners { get; set; }
        public List<HeatSinkPipeProperty> HeatSinkPipeProperties { get; set; }
    }

    public class HeatSinkPipeProperty
    {
        public Guid HeatSinkPipePropertyID { get; set; }
        public Guid HeatSinkID { get; set; }
        public double PipeSize { get; set; }
        public Nullable<double> HeaterLength { get; set; }
        public Nullable<int> TotalWatts { get; set; }
        public Nullable<double> EquivalentPipeLength { get; set; }
        public Nullable<double> FaceToFaceDimension { get; set; }
        public Nullable<double> FlangeDiameter { get; set; }
        public Nullable<double> StemDiameter { get; set; }
        public Nullable<double> FinThermalConductivity { get; set; }
        public Nullable<double> SupportLength { get; set; }
        public Nullable<double> SupportThickness { get; set; }
        public Nullable<double> NotchLength { get; set; }
        public Nullable<double> NotchDepth { get; set; }
        public double MaxRecommendedLength { get; set; }
        public bool Deprecated { get; set; }
        public HeatSink HeatSink { get; set; } // DERIVED
        public List<SegmentHeatSink> SegmentHeatSinks { get; set; }
    }

    public class SegmentHeatSink
    {
        public Guid SegmentHeatSinkID { get; set; }
        public Guid SegmentID { get; set; }
        public Guid HeatSinkPipePropertyID { get; set; }
        public int Quantity { get; set; }
        public Nullable<double> SupportSpacing { get; set; }
        public decimal AllocationMultiplier { get; set; }
        public Segment Segment { get; set; } // DERIVED
        public HeatSinkPipeProperty HeatSinkPipeProperty { get; set; } // DERIVED
        public List<DesignSegmentHeatSink> DesignSegmentHeatSinks { get; set; }
    }

    public class DesignSegmentHeatSink
    {
        public Guid SegmentHeatSinkID { get; set; }
        public Nullable<double> HeatLossPerHeatSink { get; set; }
        public double AllocationPerHeatSink { get; set; }
        public SegmentHeatSink SegmentHeatSink { get; set; } // DERIVED
    }

    public class HeatSinkOwner
    {
        public Guid HeatSinkID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public HeatSink HeatSink { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string WindowsUserSecurityIdentifier { get; set; }
        public List<CircuitOwner> CircuitOwners { get; set; }
        public List<ExternalLoadCircuitOwner> ExternalLoadCircuitOwners { get; set; }
        public List<HeatSinkOwner> HeatSinkOwners { get; set; }
        public List<InsulationTypeOwner> InsulationTypeOwners { get; set; }
        public List<PanelOwner> PanelOwners { get; set; }
        public List<PipeTypeOwner> PipeTypeOwners { get; set; }
        public List<ProcessFluidOwner> ProcessFluidOwners { get; set; }
        public List<ProjectOwner> ProjectOwners { get; set; }
    }

    public class InsulationTypeOwner
    {
        public Guid InsulationTypeID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public InsulationType InsulationType { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class InsulationType
    {
        public Guid InsulationTypeID { get; set; }
        public string InsulationTypeName { get; set; }
        public bool UserDefined { get; set; }
        public string Description { get; set; }
        public int MaxTemp { get; set; }
        public Nullable<int> MinTemp { get; set; }
        public bool UseStandardDimensions { get; set; }
        public DateTime LastModified { get; set; }
        public int UnitID { get; set; }
        public string DisplayName { get; set; }
        public Nullable<Guid> ParentInsulationTypeID { get; set; }
        public bool Promoted { get; set; }
        public Nullable<Guid> ProjectID { get; set; }
        public Unit Unit { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
        public List<InsulationDimension> InsulationDimensions { get; set; }
        public List<InsulationKValue> InsulationKValues { get; set; }
        public List<InsulationTypeOwner> InsulationTypeOwners { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class InsulationKValue
    {
        public Guid InsulationKValueID { get; set; }
        public Guid InsulationTypeID { get; set; }
        public int KValueTemp { get; set; }
        public double ThermalConductivity { get; set; }
        public InsulationType InsulationType { get; set; } // DERIVED
    }

    public class InsulationDimension
    {
        public Guid InsulationDimensionID { get; set; }
        public Guid InsulationTypeID { get; set; }
        public double NominalInsulationSize { get; set; }
        public double Thickness { get; set; }
        public double ActualInnerDiameter { get; set; }
        public double ActualOuterDiameter { get; set; }
        public InsulationType InsulationType { get; set; } // DERIVED
        public List<DesignSegment> DesignSegments { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class ExternalLoadCircuitOwner
    {
        public Guid ExternalLoadCircuitID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public Nullable<bool> IsConflict { get; set; }
        public ExternalLoadCircuit ExternalLoadCircuit { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class PanelOwner
    {
        public Guid PanelID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public Nullable<bool> IsConflict { get; set; }
        public Panel Panel { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class Panel
    {
        public Guid PanelID { get; set; }
        public Guid ProjectID { get; set; }
        public string PanelName { get; set; }
        public DateTime LastModified { get; set; }
        public Nullable<int> PanelControllerTypeID { get; set; }
        public Nullable<double> TransformerSize { get; set; }
        public Nullable<double> MainBreakerSize { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public PanelControllerType PanelControllerType { get; set; } // DERIVED
        public List<Breaker> Breakers { get; set; }
        public List<PanelOwner> PanelOwners { get; set; }
    }

    public class Breaker
    {
        public Guid BreakerID { get; set; }
        public Guid PanelID { get; set; }
        public string BreakerNumber { get; set; }
        public string ControlPoint { get; set; }
        public Nullable<int> BreakerPhaseTypeID { get; set; }
        public Nullable<int> SpaceNumber { get; set; }
        public Panel Panel { get; set; } // DERIVED
        public BreakerPhaseType BreakerPhaseType { get; set; } // DERIVED
        public List<DesignCircuitBreaker> DesignCircuitBreakers { get; set; }
        public List<DesignHeaterSetBreaker> DesignHeaterSetBreakers { get; set; }
        public List<ExternalLoadCircuitBreaker> ExternalLoadCircuitBreakers { get; set; }
    }

    public class ExternalLoadCircuitBreaker
    {
        public Guid ExternalLoadCircuitBreakerID { get; set; }
        public Guid ExternalLoadCircuitID { get; set; }
        public Guid BreakerID { get; set; }
        public ExternalLoadCircuit ExternalLoadCircuit { get; set; } // DERIVED
        public Breaker Breaker { get; set; } // DERIVED
    }

    public class ExternalLoadCircuit
    {
        public Guid ExternalLoadCircuitID { get; set; }
        public Guid ProjectID { get; set; }
        public string PipeIDNumber { get; set; }
        public string ProjectHeaterNumber { get; set; }
        public string PowerBoxTag { get; set; }
        public string RTDTag { get; set; }
        public string TeeSpliceTag { get; set; }
        public string InlineSpliceTag { get; set; }
        public string CustomerReferenceDrawing { get; set; }
        public string ThermonISODrawing { get; set; }
        public string PIDNumber { get; set; }
        public string InsulationType { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<int> MaintenanceTemp { get; set; }
        public Nullable<int> MinAmbientTemp { get; set; }
        public Nullable<int> DesignExposureTemp { get; set; }
        public Nullable<double> InsulationThickness { get; set; }
        public Nullable<double> TotalHeaterLength { get; set; }
        public Nullable<double> OperatingAmps { get; set; }
        public Nullable<double> MaxAmps { get; set; }
        public Nullable<double> OperatingWatts { get; set; }
        public Nullable<double> MaxWatts { get; set; }
        public Nullable<double> Volts { get; set; }
        public Nullable<int> AutoignitionTemp { get; set; }
        public Nullable<double> OverVoltage { get; set; }
        public Nullable<int> MaxAmbientTemp { get; set; }
        public Nullable<int> HiLimitSetPoint { get; set; }
        public Nullable<int> TClassID { get; set; }
        public string Name { get; set; }
        public int EntityOrder { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsProjectDefault { get; set; }
        public Nullable<int> ElectricalStandardsClassID { get; set; }
        public Nullable<int> ElectricalStandardsDivisionOrZoneID { get; set; }
        public Nullable<int> ElectricalStandardsGroupID { get; set; }
        public string DrawingNumber { get; set; }
        public string DrawingRevision { get; set; }
        public Nullable<int> DrawingSheet { get; set; }
        public Nullable<int> DrawingSheets { get; set; }
        public string Module { get; set; }
        public string WorkPackage { get; set; }
        public string Area { get; set; }
        public Nullable<int> CircuitBreakerSize { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public TClass TClass { get; set; } // DERIVED
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public ElectricalStandardsDivisionOrZone ElectricalStandardsDivisionOrZone { get; set; } // DERIVED
        public ElectricalStandardsGroup ElectricalStandardsGroup { get; set; } // DERIVED
        public List<BillOfMaterialsExternalLoadEntry> BillOfMaterialsExternalLoadEntries { get; set; }
        public List<ExternalLoadCircuitBreaker> ExternalLoadCircuitBreakers { get; set; }
        public List<ExternalLoadCircuitOwner> ExternalLoadCircuitOwners { get; set; }
    }

    public class BillOfMaterialsExternalLoadEntry
    {
        public Guid BillOfMaterialsExternalLoadEntryID { get; set; }
        public Guid ExternalLoadCircuitID { get; set; }
        public int ItemNumber { get; set; }
        public string PartNumber { get; set; }
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        public string DescriptionShort { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public ExternalLoadCircuit ExternalLoadCircuit { get; set; } // DERIVED
    }

    public class ElectricalStandardsGroup
    {
        public int ElectricalStandardsGroupID { get; set; }
        public int ElectricalStandardsClassID { get; set; }
        public string GroupName { get; set; }
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public List<CableFamilyCertificationCompatibility> CableFamilyCertificationCompatibilities { get; set; }
        public List<CatalogPartCertificationCompatibility> CatalogPartCertificationCompatibilities { get; set; }
        public List<Circuit> Circuits { get; set; }
        public List<ExternalLoadCircuit> ExternalLoadCircuits { get; set; }
    }

    public class CatalogPartCertificationCompatibility
    {
        public int CatalogPartCertificationCompatibilityID { get; set; }
        public int CatalogPartID { get; set; }
        public int ElectricalStandardsClassID { get; set; }
        public Nullable<int> ElectricalStandardsDivisionOrZoneID { get; set; }
        public Nullable<int> ElectricalStandardsGroupID { get; set; }
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public ElectricalStandardsDivisionOrZone ElectricalStandardsDivisionOrZone { get; set; } // DERIVED
        public ElectricalStandardsGroup ElectricalStandardsGroup { get; set; } // DERIVED
    }

    public class CableFamilyCertificationCompatibility
    {
        public int CableFamilyCertificationCompatibilityID { get; set; }
        public int CableFamilyCertificationID { get; set; }
        public int ElectricalStandardsClassID { get; set; }
        public Nullable<int> ElectricalStandardsDivisionOrZoneID { get; set; }
        public Nullable<int> ElectricalStandardsGroupID { get; set; }
        public CableFamilyCertification CableFamilyCertification { get; set; } // DERIVED
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public ElectricalStandardsDivisionOrZone ElectricalStandardsDivisionOrZone { get; set; } // DERIVED
        public ElectricalStandardsGroup ElectricalStandardsGroup { get; set; } // DERIVED
    }

    public class CableFamilyCertification
    {
        public int CableFamilyCertificationID { get; set; }
        public int CableFamilyID { get; set; }
        public string CatalogNumberFormat { get; set; }
        public bool IsOrganicsExposureAllowed { get; set; }
        public CableFamily CableFamily { get; set; } // DERIVED
        public List<CableFamilyCertificationCompatibility> CableFamilyCertificationCompatibilities { get; set; }
        public List<CablePart> CableParts { get; set; }
    }

    public class CablePart
    {
        public int CablePartID { get; set; }
        public int CableFamilyCertificationID { get; set; }
        public int CableID { get; set; }
        public string PartNumber { get; set; }
        public CableFamilyCertification CableFamilyCertification { get; set; } // DERIVED
        public Cable Cable { get; set; } // DERIVED
        public List<CablePartTClassCompatibility> CablePartTClassCompatibilities { get; set; }
    }

    public class CablePartTClassCompatibility
    {
        public int CablePartTClassCompatibilityID { get; set; }
        public int CablePartID { get; set; }
        public int TClassCompatibilityID { get; set; }
        public CablePart CablePart { get; set; } // DERIVED
        public TClassCompatibility TClassCompatibility { get; set; } // DERIVED
    }

    public class TClassCompatibility
    {
        public int TClassCompatibilityID { get; set; }
        public int TClassID { get; set; }
        public int ElectricalStandardsClassID { get; set; }
        public TClass TClass { get; set; } // DERIVED
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public List<CablePartTClassCompatibility> CablePartTClassCompatibilities { get; set; }
    }

    public class CableFamily
    {
        public int CableFamilyID { get; set; }
        public string CableFamilyName { get; set; }
        public string Description { get; set; }
        public bool IsParallel { get; set; }
        public int NumberOfConductors { get; set; }
        public Nullable<bool> Zoned { get; set; }
        public int MaxMaintainTempF { get; set; }
        public int MaxMaintainTempC { get; set; }
        public int MaxExposureTempF { get; set; }
        public int MaxExposureTempC { get; set; }
        public Nullable<int> MaxIntermittentOffTempF { get; set; }
        public Nullable<int> MaxIntermittentOffTempC { get; set; }
        public Nullable<int> MaxIntermittentOnTempF { get; set; }
        public Nullable<int> MaxIntermittentOnTempC { get; set; }
        public Nullable<double> MaxWattDensityPerFoot { get; set; }
        public Nullable<double> ConductorCoefficient1 { get; set; }
        public Nullable<double> ConductorCoefficient2 { get; set; }
        public Nullable<double> ConductorCoefficient3 { get; set; }
        public Nullable<double> BusWireOhmsPerFootAt68F { get; set; }
        public Nullable<double> BusWireAlphaCoefficient { get; set; }
        public double StandardChannelHeight { get; set; }
        public Nullable<double> SpiralChannelHeight { get; set; }
        public bool IsUSPartNumber { get; set; }
        public string CatalogFormatArg0 { get; set; }
        public bool HasOptionFOJ { get; set; }
        public bool SupportsOrganicsExposure { get; set; }
        public double MetallicPipeChannelDeratingFactor { get; set; }
        public Nullable<double> NonMetallicPipeChannelDeratingFactor { get; set; }
        public bool IsValidForNonMetallicPipe { get; set; }
        public string DescriptionShort { get; set; }
        public double MetallicPipeChannelDeratingFactorTop { get; set; }
        public bool Deprecated { get; set; }
        public Nullable<int> NextOrdinalID { get; set; }
        public List<Cable> Cables { get; set; }
        public List<CableFamilyCertification> CableFamilyCertifications { get; set; }
        public List<CatalogPartCableFamilyCompatibility> CatalogPartCableFamilyCompatibilities { get; set; }
        public List<Compatibility> Compatibilities { get; set; }
        public List<Connection> Connections { get; set; }
    }

    public class CatalogPartCableFamilyCompatibility
    {
        public int CatalogPartCableFamilyCompatibilityID { get; set; }
        public int CatalogPartID { get; set; }
        public int CableFamilyID { get; set; }
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public CableFamily CableFamily { get; set; } // DERIVED
    }

    public class Compatibility
    {
        public int CompatibilityID { get; set; }
        public int CompatibilityTypeID { get; set; }
        public Nullable<int> TemperatureControlTypeID { get; set; }
        public int CableFamilyID { get; set; }
        public int CompatibilityEntryID { get; set; }
        public bool IsDefault { get; set; }
        public int ElectricalStandardsAgencyID { get; set; }
        public Nullable<int> ElectricalStandardsDivisionOrZoneSetID { get; set; }
        public CompatibilityType CompatibilityType { get; set; } // DERIVED
        public TemperatureControlType TemperatureControlType { get; set; } // DERIVED
        public CableFamily CableFamily { get; set; } // DERIVED
        public CompatibilityEntry CompatibilityEntry { get; set; } // DERIVED
        public ElectricalStandardsAgency ElectricalStandardsAgency { get; set; } // DERIVED
        public ElectricalStandardsDivisionOrZoneSet ElectricalStandardsDivisionOrZoneSet { get; set; } // DERIVED
    }

    public class ElectricalStandardsDivisionOrZoneSet
    {
        public int ElectricalStandardsDivisionOrZoneSetID { get; set; }
        public string DivisionOrZoneSetName { get; set; }
        public List<Compatibility> Compatibilities { get; set; }
        public List<ElectricalStandardsDivisionOrZone> ElectricalStandardsDivisionOrZones { get; set; }
    }

    public class ElectricalStandardsAgency
    {
        public int ElectricalStandardsAgencyID { get; set; }
        public string AreaName { get; set; }
        public int ClassificationTypeID { get; set; }
        public bool AutoignitionTempEnabled { get; set; }
        public bool UseAlphaTClasses { get; set; }
        public ElectricalStandardsClassificationType ClassificationType { get; set; } // DERIVED
        public List<Compatibility> Compatibilities { get; set; }
        public List<ElectricalStandardsClass> ElectricalStandardsClassList { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<UserSettings> UserSettingsList { get; set; }
    }

    public class UserSettings
    {
        public int UserSettingsID { get; set; }
        public string Username { get; set; }
        public Nullable<int> DefaultUnitID { get; set; }
        public string VisiTraceDefaultFilename { get; set; }
        public Nullable<int> DefaultElectricalStandardsAgencyId { get; set; }
        public int UserSettingDefaultPaperTypeID { get; set; }
        public Unit DefaultUnit { get; set; } // DERIVED
        public ElectricalStandardsAgency DefaultElectricalStandardsAgency { get; set; } // DERIVED
        public UserSettingDefaultPaperType UserSettingDefaultPaperType { get; set; } // DERIVED
    }

    public class UserSettingDefaultPaperType
    {
        public int UserSettingDefaultPaperTypeID { get; set; }
        public string UserSettingDefaultPaperTypeName { get; set; }
        public List<UserSettings> UserSettingsList { get; set; }
    }

    public class ElectricalStandardsClassificationType
    {
        public int ElectricalStandardsClassificationTypeID { get; set; }
        public string ClassificationTypeName { get; set; }
        public string ClassificationTypeLabelText { get; set; }
        public List<ElectricalStandardsAgency> ElectricalStandardsAgencies { get; set; }
    }

    public class CompatibilityEntry
    {
        public int CompatibilityEntryID { get; set; }
        public int EntryTypeID { get; set; }
        public string EntryName { get; set; }
        public CompatibilityEntryType EntryType { get; set; } // DERIVED
        public List<Compatibility> Compatibilities { get; set; }
        public List<CompatibilityCableSelectEntry> CompatibilityCableSelectEntries { get; set; }
        public List<CompatibilityCatalogPartEntry> CompatibilityCatalogPartEntries { get; set; }
        public List<CompatibilityLocalControlGroupEntry> CompatibilityLocalControlGroupEntries { get; set; }
        public List<CompatibilityVoltageSelectEntry> CompatibilityVoltageSelectEntries { get; set; }
        public List<Component> Components { get; set; }
    }

    public class Component
    {
        public int ComponentID { get; set; }
        public bool IsParallelConfiguration { get; set; }
        public int CompatibilityEntryID { get; set; }
        public int ComponentTypeID { get; set; }
        public int PETK { get; set; }
        public int SCTK { get; set; }
        public int ET { get; set; }
        public int MaxCableConnections { get; set; }
        public Nullable<bool> AreKitsPerCablePass { get; set; }
        public CompatibilityEntry CompatibilityEntry { get; set; } // DERIVED
        public ComponentType ComponentType { get; set; } // DERIVED
        public List<ComponentCatalogPart> ComponentCatalogParts { get; set; }
    }

    public class ComponentCatalogPart
    {
        public int ComponentCatalogPartID { get; set; }
        public int ComponentID { get; set; }
        public int CatalogPartID { get; set; }
        public Component Component { get; set; } // DERIVED
        public CatalogPart CatalogPart { get; set; } // DERIVED
    }

    public class ComponentType
    {
        public int ComponentTypeID { get; set; }
        public string ComponentConfiguration { get; set; }
        public Nullable<int> CableConnectionsPerCablePass { get; set; }
        public string ComponentTypeName { get; set; }
        public string ComponentTypeDescription { get; set; }
        public List<Component> Components { get; set; }
        public List<ConnectionComponentTag> ConnectionComponentTags { get; set; }
    }

    public class CompatibilityVoltageSelectEntry
    {
        public int CatalogPartID { get; set; }
        public int CompatibilityEntryID { get; set; }
        public int Voltage { get; set; }
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public CompatibilityEntry CompatibilityEntry { get; set; } // DERIVED
    }

    public class CompatibilityLocalControlGroupEntry
    {
        public int CatalogPartLocalControlGroupID { get; set; }
        public int CompatibilityEntryID { get; set; }
        public CatalogPartLocalControlGroup CatalogPartLocalControlGroup { get; set; } // DERIVED
        public CompatibilityEntry CompatibilityEntry { get; set; } // DERIVED
    }

    public class CatalogPartLocalControlGroup
    {
        public int CatalogPartLocalControlGroupID { get; set; }
        public string ControlGroupName { get; set; }
        public Nullable<int> CatalogPartImageID { get; set; }
        public int ControlTypeID { get; set; }
        public Nullable<int> ControlSwitchTypeID { get; set; }
        public int RequiredSensorQuantity { get; set; }
        public bool HasPowerConnection { get; set; }
        public CatalogPartImage CatalogPartImage { get; set; } // DERIVED
        public CatalogPartControlType ControlType { get; set; } // DERIVED
        public CatalogPartControlSwitchType ControlSwitchType { get; set; } // DERIVED
        public List<CatalogPartLocalControl> CatalogPartLocalControls { get; set; }
        public List<CatalogPartSensorCompatibility> CatalogPartSensorCompatibilities { get; set; }
        public List<CompatibilityLocalControlGroupEntry> CompatibilityLocalControlGroupEntries { get; set; }
    }

    public class CatalogPartSensorCompatibility
    {
        public int CatalogPartSensorCompatibilityID { get; set; }
        public int CatalogPartSensorID { get; set; }
        public int CatalogPartLocalControlGroupID { get; set; }
        public CatalogPartSensor CatalogPartSensor { get; set; } // DERIVED
        public CatalogPartLocalControlGroup CatalogPartLocalControlGroup { get; set; } // DERIVED
    }

    public class CatalogPartSensor
    {
        public int CatalogPartID { get; set; }
        public Nullable<int> MinControlTempF { get; set; }
        public Nullable<int> MinControlTempC { get; set; }
        public Nullable<int> MaxControlTempF { get; set; }
        public Nullable<int> MaxControlTempC { get; set; }
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public List<CatalogPartSensorCompatibility> CatalogPartSensorCompatibilities { get; set; }
    }

    public class CatalogPartLocalControl
    {
        public int CatalogPartID { get; set; }
        public int LocalControlGroupID { get; set; }
        public Nullable<bool> IsOperatingTemperatureMetric { get; set; }
        public Nullable<int> MinControlTempF { get; set; }
        public Nullable<int> MinControlTempC { get; set; }
        public Nullable<int> MaxControlTempF { get; set; }
        public Nullable<int> MaxControlTempC { get; set; }
        public int MinVoltage { get; set; }
        public int MaxVoltage { get; set; }
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public CatalogPartLocalControlGroup LocalControlGroup { get; set; } // DERIVED
        public List<CatalogPartControlMaxAmbientSwitchRating> CatalogPartControlMaxAmbientSwitchRatings { get; set; }
        public List<CatalogPartControlSwitchRating> CatalogPartControlSwitchRatings { get; set; }
    }

    public class CatalogPartControlSwitchRating
    {
        public int CatalogPartControlSwitchRatingID { get; set; }
        public int CatalogPartLocalControlID { get; set; }
        public int SwitchRatingVoltage { get; set; }
        public int SwitchRatingAmperage { get; set; }
        public CatalogPartLocalControl CatalogPartLocalControl { get; set; } // DERIVED
    }

    public class CatalogPartControlMaxAmbientSwitchRating
    {
        public int CatalogPartControlMaxAmbientSwitchRatingID { get; set; }
        public int CatalogPartLocalControlID { get; set; }
        public int SwitchRatingMaxAmbientTempC { get; set; }
        public int SwitchRatingAmperage { get; set; }
        public CatalogPartLocalControl CatalogPartLocalControl { get; set; } // DERIVED
    }

    public class CatalogPartControlSwitchType
    {
        public int CatalogPartControlSwitchTypeID { get; set; }
        public string SwitchTypeName { get; set; }
        public List<CatalogPartLocalControlGroup> CatalogPartLocalControlGroups { get; set; }
    }

    public class CatalogPartControlType
    {
        public int CatalogPartControlTypeID { get; set; }
        public string ControlTypeName { get; set; }
        public List<CatalogPartLocalControlGroup> CatalogPartLocalControlGroups { get; set; }
        public List<ComponentControlTypeSelection> ComponentControlTypeSelections { get; set; }
    }

    public class ComponentControlTypeSelection
    {
        public int ComponentControlTypeSelectionID { get; set; }
        public Nullable<int> CatalogPartControlTypeID { get; set; }
        public string ControlTypeSelectionName { get; set; }
        public CatalogPartControlType CatalogPartControlType { get; set; } // DERIVED
        public List<ConnectionComponent> ConnectionComponents { get; set; }
        public List<DefaultComponent> DefaultComponents { get; set; }
    }

    public class DefaultComponent
    {
        public Guid DefaultComponentID { get; set; }
        public Nullable<int> LocalControlTypeSelectionID { get; set; }
        public Nullable<Guid> PowerComponentCatalogPartID { get; set; }
        public Nullable<Guid> SpliceComponentCatalogPartID { get; set; }
        public Nullable<Guid> TeeComponentCatalogPartID { get; set; }
        public Nullable<Guid> EndComponentCatalogPartID { get; set; }
        public Nullable<Guid> LocalControlID { get; set; }
        public Nullable<Guid> SensorID { get; set; }
        public ComponentControlTypeSelection LocalControlTypeSelection { get; set; } // DERIVED
        public SelectableCatalogPart PowerComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart SpliceComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart TeeComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart EndComponentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart LocalControl { get; set; } // DERIVED
        public SelectableCatalogPart Sensor { get; set; } // DERIVED
        public List<SelectableCatalogPart> SelectableCatalogParts { get; set; } // DERIVED
        public List<ConnectionDefaultComponent> ConnectionDefaultComponents { get; set; }
        public List<ProjectDefaultComponent> ProjectDefaultComponents { get; set; }
    }

    public class ProjectDefaultComponent
    {
        public Guid ProjectID { get; set; }
        public Guid DefaultComponentID { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public DefaultComponent DefaultComponent { get; set; } // DERIVED
        public List<DefaultComponent> DefaultComponents { get; set; }
    }

    public class SelectableCatalogPart
    {
        public string CustomComponentDisplayName { get; set; }
        public int ComponentFieldID { get; set; }
        public Nullable<Guid> ProjectID { get; set; }
        public Nullable<int> CatalogPartID { get; set; }
        public string CatalogNumber { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public Guid SelectableCatalogPartID { get; set; }
        public string DescriptionShort { get; set; }
        public ComponentField ComponentField { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public List<AvailableComponent> AvailableComponents { get; set; }
        public List<ConnectionComponent> ConnectionComponents { get; set; }
        public List<DefaultComponent> DefaultComponents { get; set; }
        public List<ProjectCatalogPartExtraRequirement> ProjectCatalogPartExtraRequirements { get; set; }
    }

    public class ProjectCatalogPartExtraRequirement
    {
        public Guid ProjectCatalogPartExtraRequirementID { get; set; }
        public Guid ParentCatalogPartID { get; set; }
        public Guid RequiredCatalogPartID { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public bool RoundUp { get; set; }
        public Guid ProjectID { get; set; }
        public SelectableCatalogPart ParentCatalogPart { get; set; } // DERIVED
        public SelectableCatalogPart RequiredCatalogPart { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
        public List<SelectableCatalogPart> SelectableCatalogParts { get; set; } // DERIVED
    }

    public class ComponentField
    {
        public int ComponentFieldID { get; set; }
        public string ComponentFieldType { get; set; }
        public List<AvailableComponent> AvailableComponents { get; set; }
        public List<SelectableCatalogPart> SelectableCatalogParts { get; set; }
    }

    public class AvailableComponent
    {
        public bool IsParallel { get; set; }
        public Guid ProjectID { get; set; }
        public int ComponentFieldID { get; set; }
        public int Ordinal { get; set; }
        public Guid AvailableComponentID { get; set; }
        public Nullable<Guid> SelectableCatalogPartID { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public ComponentField ComponentField { get; set; } // DERIVED
        public SelectableCatalogPart SelectableCatalogPart { get; set; } // DERIVED
    }

    public class CompatibilityCatalogPartEntry
    {
        public int CatalogPartID { get; set; }
        public int CompatibilityEntryID { get; set; }
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public CompatibilityEntry CompatibilityEntry { get; set; } // DERIVED
    }

    public class CompatibilityCableSelectEntry
    {
        public int CompatibilityCableSelectEntryID { get; set; }
        public int CompatibilityEntryID { get; set; }
        public int CatalogPartID { get; set; }
        public int CableID { get; set; }
        public CompatibilityEntry CompatibilityEntry { get; set; } // DERIVED
        public CatalogPart CatalogPart { get; set; } // DERIVED
        public Cable Cable { get; set; } // DERIVED
    }

    public class CatalogPart
    {
        public int CatalogPartID { get; set; }
        public int CatalogPartTypeID { get; set; }
        public string CatalogNumber { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public Nullable<int> CatalogPartImageID { get; set; }
        public Nullable<int> MaxPipeExposureTempF { get; set; }
        public Nullable<int> MaxPipeExposureTempC { get; set; }
        public Nullable<int> MinInstallTempF { get; set; }
        public Nullable<int> MinInstallTempC { get; set; }
        public Nullable<int> MinAmbientTempRangeF { get; set; }
        public Nullable<int> MinAmbientTempRangeC { get; set; }
        public Nullable<int> MaxAmbientTempRangeF { get; set; }
        public Nullable<int> MaxAmbientTempRangeC { get; set; }
        public bool AmbientDependentForTRating { get; set; }
        public Nullable<int> MaxAmbientT6RatingF { get; set; }
        public Nullable<int> MaxAmbientT6RatingC { get; set; }
        public Nullable<int> MaxAmbientT5RatingF { get; set; }
        public Nullable<int> MaxAmbientT5RatingC { get; set; }
        public Nullable<int> MaxAmbientT4RatingF { get; set; }
        public Nullable<int> MaxAmbientT4RatingC { get; set; }
        public Nullable<int> MaxCurrentRatingAmps { get; set; }
        public bool CurrentDependentForTRating { get; set; }
        public Nullable<int> MaxCurrentT6RatingAmps { get; set; }
        public Nullable<int> MaxCurrentT4RatingAmps { get; set; }
        public Nullable<int> MaxVoltageRating { get; set; }
        public bool IsPowerOutputDependent { get; set; }
        public string DescriptionShort { get; set; }
        public Nullable<int> MaxCurrentT5RatingAmps { get; set; }
        public Nullable<int> LowAmbientLimitTempF { get; set; }
        public Nullable<int> LowAmbientLimitTempC { get; set; }
        public Nullable<int> LowAmbientMaxCurrentT4RatingAmps { get; set; }
        public Nullable<int> LowAmbientMaxCurrentT5RatingAmps { get; set; }
        public Nullable<int> LowAmbientMaxCurrentT6RatingAmps { get; set; }
        public Nullable<int> ParentCatalogPartID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public CatalogPartType CatalogPartType { get; set; } // DERIVED
        public CatalogPartImage CatalogPartImage { get; set; } // DERIVED
        public List<CatalogPartCableFamilyCompatibility> CatalogPartCableFamilyCompatibilities { get; set; }
        public List<CatalogPartCertificationCompatibility> CatalogPartCertificationCompatibilities { get; set; }
        public List<CatalogPartLocalControl> CatalogPartLocalControls { get; set; }
        public List<CatalogPartSensor> CatalogPartSensors { get; set; }
        public List<CompatibilityCableSelectEntry> CompatibilityCableSelectEntries { get; set; }
        public List<CompatibilityCatalogPartEntry> CompatibilityCatalogPartEntries { get; set; }
        public List<CompatibilityVoltageSelectEntry> CompatibilityVoltageSelectEntries { get; set; }
        public List<ComponentCatalogPart> ComponentCatalogParts { get; set; }
        public List<SelectableCatalogPart> SelectableCatalogParts { get; set; }
    }

    public class CatalogPartImage
    {
        public int CatalogPartImageID { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public List<CatalogPart> CatalogParts { get; set; }
        public List<CatalogPartLocalControlGroup> CatalogPartLocalControlGroups { get; set; }
    }

    public class CatalogPartType
    {
        public int CatalogPartTypeID { get; set; }
        public string CatalogPartTypeName { get; set; }
        public List<CatalogPart> CatalogParts { get; set; }
    }

    public class CompatibilityEntryType
    {
        public int CompatibilityEntryTypeID { get; set; }
        public string EntryTypeName { get; set; }
        public List<CompatibilityEntry> CompatibilityEntries { get; set; }
    }

    public class TemperatureControlType
    {
        public int TemperatureControlTypeID { get; set; }
        public string TemperatureControlTypeName { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public List<Circuit> Circuits { get; set; }
        public List<Compatibility> Compatibilities { get; set; }
    }

    public class CompatibilityType
    {
        public int CompatibilityTypeID { get; set; }
        public string CompatibilityTypeName { get; set; }
        public string ExcelSheetName { get; set; }
        public List<Compatibility> Compatibilities { get; set; }
    }

    public class Cable
    {
        public int CableID { get; set; }
        public string CatalogNumber { get; set; }
        public Nullable<decimal> CatalogFormatArg1 { get; set; }
        public Nullable<int> CatalogFormatArg2 { get; set; }
        public int MaxOpConductorTempF { get; set; }
        public int MaxOpConductorTempC { get; set; }
        public int MaxHazConductorTempF { get; set; }
        public int MaxHazConductorTempC { get; set; }
        public Nullable<int> MaxHazSheathTempF { get; set; }
        public Nullable<int> MaxHazSheathTempC { get; set; }
        public Nullable<int> MaxSheathTempF { get; set; }
        public Nullable<int> MaxSheathTempC { get; set; }
        public Nullable<int> MinVAC { get; set; }
        public int MaxVAC { get; set; }
        public Nullable<int> OperatingAmps { get; set; }
        public Nullable<int> StartupAmps { get; set; }
        public Nullable<double> OhmsPerFootAt68F { get; set; }
        public Nullable<double> AlphaCoefficient { get; set; }
        public Nullable<double> DiameterFt { get; set; }
        public double CableArea { get; set; }
        public Nullable<int> MaxLengthFt { get; set; }
        public Nullable<double> WPCM { get; set; }
        public int CableFamilyID { get; set; }
        public int CableNumber { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<double> OhmsPerZone { get; set; }
        public CableFamily CableFamily { get; set; } // DERIVED
        public List<CableCoefficient> CableCoefficients { get; set; }
        public List<CablePart> CableParts { get; set; }
        public List<CompatibilityCableSelectEntry> CompatibilityCableSelectEntries { get; set; }
        public List<DesignMIQHeater> DesignMIQHeaters { get; set; }
        public List<DesignSegment> DesignSegments { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class DesignMIQHeater
    {
        public Guid DesignMIQHeaterID { get; set; }
        public Guid DesignHeaterSetID { get; set; }
        public int CableID { get; set; }
        public double Length { get; set; }
        public string TagNumber { get; set; }
        public int HeaterOrder { get; set; }
        public DesignHeaterSet DesignHeaterSet { get; set; } // DERIVED
        public Cable Cable { get; set; } // DERIVED
        public List<DesignSegmentMIQHeater> DesignSegmentMIQHeaters { get; set; }
    }

    public class DesignSegmentMIQHeater
    {
        public Guid DesignSegmentMIQHeaterID { get; set; }
        public Guid DesignMIQHeaterID { get; set; }
        public Guid DesignSegmentID { get; set; }
        public DesignMIQHeater DesignMIQHeater { get; set; } // DERIVED
        public DesignSegment DesignSegment { get; set; } // DERIVED
    }

    public class CableCoefficient
    {
        public int CableCoefficientID { get; set; }
        public int CoefficientTypeID { get; set; }
        public int CableID { get; set; }
        public int Degree { get; set; }
        public double Coefficient { get; set; }
        public CoefficientType CoefficientType { get; set; } // DERIVED
        public Cable Cable { get; set; } // DERIVED
    }

    public class CoefficientType
    {
        public int CoefficientTypeID { get; set; }
        public string CoefficientTypeName { get; set; }
        public List<CableCoefficient> CableCoefficients { get; set; }
    }

    public class ElectricalStandardsDivisionOrZone
    {
        public int ElectricalStandardsDivisionOrZoneID { get; set; }
        public int ElectricalStandardsClassID { get; set; }
        public string DivisionOrZoneName { get; set; }
        public bool IsMIQHazardous { get; set; }
        public bool IsDivisionOrZone1 { get; set; }
        public bool IsDivisionOrZone2 { get; set; }
        public int ElectricalStandardsDivisionOrZoneSetID { get; set; }
        public ElectricalStandardsClass ElectricalStandardsClass { get; set; } // DERIVED
        public ElectricalStandardsDivisionOrZoneSet ElectricalStandardsDivisionOrZoneSet { get; set; } // DERIVED
        public List<CableFamilyCertificationCompatibility> CableFamilyCertificationCompatibilities { get; set; }
        public List<CatalogPartCertificationCompatibility> CatalogPartCertificationCompatibilities { get; set; }
        public List<Circuit> Circuits { get; set; }
        public List<ExternalLoadCircuit> ExternalLoadCircuits { get; set; }
    }

    public class ElectricalStandardsClass
    {
        public int ElectricalStandardsClassID { get; set; }
        public int ElectricalStandardsAgencyID { get; set; }
        public string ClassName { get; set; }
        public bool IsOrdinary { get; set; }
        public ElectricalStandardsAgency ElectricalStandardsAgency { get; set; } // DERIVED
        public List<CableFamilyCertificationCompatibility> CableFamilyCertificationCompatibilities { get; set; }
        public List<CatalogPartCertificationCompatibility> CatalogPartCertificationCompatibilities { get; set; }
        public List<Circuit> Circuits { get; set; }
        public List<ElectricalStandardsDivisionOrZone> ElectricalStandardsDivisionOrZones { get; set; }
        public List<ElectricalStandardsGroup> ElectricalStandardsGroups { get; set; }
        public List<ExternalLoadCircuit> ExternalLoadCircuits { get; set; }
        public List<TClassCompatibility> TClassCompatibilities { get; set; }
    }

    public class TClass
    {
        public int TClassID { get; set; }
        public string TClassName { get; set; }
        public int AutoIgnitionTempF { get; set; }
        public List<Circuit> Circuits { get; set; }
        public List<ExternalLoadCircuit> ExternalLoadCircuits { get; set; }
        public List<TClassCompatibility> TClassCompatibilities { get; set; }
    }

    public class DesignHeaterSetBreaker
    {
        public Guid DesignHeaterSetBreakerID { get; set; }
        public Guid DesignHeaterSetID { get; set; }
        public Guid BreakerID { get; set; }
        public DesignHeaterSet DesignHeaterSet { get; set; } // DERIVED
        public Breaker Breaker { get; set; } // DERIVED
    }

    public class DesignCircuitBreaker
    {
        public Guid DesignCircuitBreakerID { get; set; }
        public Guid DesignCircuitID { get; set; }
        public Guid BreakerID { get; set; }
        public DesignCircuit DesignCircuit { get; set; } // DERIVED
        public Breaker Breaker { get; set; } // DERIVED
    }

    public class BreakerPhaseType
    {
        public int BreakerPhaseTypeID { get; set; }
        public string BreakerPhaseTypeName { get; set; }
        public List<Breaker> Breakers { get; set; }
    }

    public class PanelControllerType
    {
        public int PanelControllerTypeID { get; set; }
        public string PanelControllerTypeName { get; set; }
        public List<Panel> Panels { get; set; }
    }

    public class PipeTypeOwner
    {
        public Guid PipeTypeID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public PipeType PipeType { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class PipeType
    {
        public Guid PipeTypeID { get; set; }
        public string PipeTypeName { get; set; }
        public bool UserDefined { get; set; }
        public string Description { get; set; }
        public double Density { get; set; }
        public double SpecificHeat { get; set; }
        public int MaxTemp { get; set; }
        public double ThermalConductivity { get; set; }
        public DateTime LastModified { get; set; }
        public int UnitID { get; set; }
        public string DisplayName { get; set; }
        public Nullable<Guid> ParentPipeTypeID { get; set; }
        public bool Promoted { get; set; }
        public Nullable<Guid> ProjectID { get; set; }
        public Unit Unit { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
        public List<PipeSize> PipeSizes { get; set; }
        public List<PipeTypeOwner> PipeTypeOwners { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class PipeSize
    {
        public Guid PipeSizeID { get; set; }
        public Guid PipeTypeID { get; set; }
        public double NominalDiameter { get; set; }
        public double ActualInnerDiameter { get; set; }
        public double ActualOuterDiameter { get; set; }
        public PipeType PipeType { get; set; } // DERIVED
        public List<Segment> Segments { get; set; }
    }

    public class ProcessFluidOwner
    {
        public Guid ProcessFluidID { get; set; }
        public Guid UserID { get; set; }
        public Nullable<Guid> ServerRevision { get; set; }
        public Nullable<DateTime> ServerRevisionDate { get; set; }
        public byte[] HashValue { get; set; }
        public Nullable<Guid> ClientRevision { get; set; }
        public ProcessFluid ProcessFluid { get; set; } // DERIVED
        public User User { get; set; } // DERIVED
    }

    public class ProcessFluid
    {
        public Guid ProcessFluidID { get; set; }
        public string ProcessFluidName { get; set; }
        public string Description { get; set; }
        public Nullable<double> MeltingPoint { get; set; }
        public double Density { get; set; }
        public double SpecificHeat { get; set; }
        public Nullable<double> HeatOfFusion { get; set; }
        public Nullable<double> HeatOfVaporization { get; set; }
        public Nullable<double> BoilingPoint { get; set; }
        public Nullable<double> MaxTemp { get; set; }
        public bool UserDefined { get; set; }
        public DateTime LastModified { get; set; }
        public int UnitID { get; set; }
        public string DisplayName { get; set; }
        public Nullable<Guid> ParentProcessFluidID { get; set; }
        public bool Promoted { get; set; }
        public Nullable<Guid> ProjectID { get; set; }
        public Unit Unit { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
        public List<Circuit> Circuits { get; set; }
        public List<ProcessFluidOwner> ProcessFluidOwners { get; set; }
    }

    public class HeatSinkCableCalculation
    {
        public int HeatSinkCableCalculationID { get; set; }
        public string Description { get; set; }
        public List<HeatSink> HeatSinks { get; set; }
    }

    public class HeatSinkType
    {
        public int HeatSinkTypeID { get; set; }
        public string HeatSinkTypeName { get; set; }
        public List<HeatSink> HeatSinks { get; set; }
    }

    public class Unit
    {
        public int UnitID { get; set; }
        public bool PipeMetric { get; set; }
        public bool InsulationMetric { get; set; }
        public bool TemperatureMetric { get; set; }
        public bool GeneralMetric { get; set; }
        public List<HeatSink> HeatSinks { get; set; }
        public List<InsulationType> InsulationTypes { get; set; }
        public List<PipeType> PipeTypes { get; set; }
        public List<ProcessFluid> ProcessFluids { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<UnitMeasurement> UnitMeasurements { get; set; }
        public List<UserSettings> UserSettingsList { get; set; }
    }

    public class UnitMeasurement
    {
        public Guid UnitMeasurementID { get; set; }
        public Nullable<int> UnitMeasurementTypeID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> MeasurementID { get; set; }
        public UnitMeasurementType UnitMeasurementType { get; set; } // DERIVED
        public Unit Unit { get; set; } // DERIVED
    }

    public class UnitMeasurementType
    {
        public int UnitMeasurementTypeID { get; set; }
        public string UnitMeasurementTypeName { get; set; }
        public List<UnitMeasurement> UnitMeasurements { get; set; }
    }

    public class ProjectInformationDto
    {
        public string ProjectID { get; set; }
        public int projectIdentifier { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectOwnerName { get; set; }
        public DateTime ProjectLastModified { get; set; }
        public DateTime CircuitLastModified { get; set; }
        public int TotalCircuits { get; set; }
        public int TotalDesignedCircuits { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseLocation { get; set; }
        public object DatabaseConnectionString { get; set; }
        public string DatabaseVersion { get; set; }
        public object DatabaseType { get; set; }
        public object CompuTraceVersion { get; set; }

        public string ConnectionId { get; set; }
    }

    public class ProjectDto
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public DateTime LastModified { get; set; }
        public string JobNumber { get; set; }
        public string Customer { get; set; }
        public string Location { get; set; }
        public string SBU { get; set; }
        public string ProjectManager { get; set; }
        public string Designer { get; set; }
        public string PurchaseOrder { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public DateTime DateEntered { get; set; }
        public Nullable<DateTime> DateDue { get; set; }
        public string ForCustomer { get; set; }
        public string ForLocation { get; set; }
        public string ByCustomer { get; set; }
        public string ByLocation { get; set; }
        public string Remarks { get; set; }
        public int UnitID { get; set; }
        public double WarningLabelInterval { get; set; }
        public double MaxSpiralRatio { get; set; }
        public int CircumferentialFixingTapeID { get; set; }
        public int AluminumTapeID { get; set; }
        public double DefaultTerminationAllowance { get; set; }
        public int ElectricalStandardsAgencyID { get; set; }
        public int CultureID { get; set; }
        public bool HeatSinkAllocationPerPass { get; set; }
        public double DefaultConstructionAllowance { get; set; }
        public Unit Unit { get; set; } // DERIVED
        public CircumferentialFixingTape CircumferentialFixingTape { get; set; } // DERIVED
        public AluminumTape AluminumTape { get; set; } // DERIVED
        public ElectricalStandardsAgency ElectricalStandardsAgency { get; set; } // DERIVED
        public Culture Culture { get; set; } // DERIVED
        public List<AvailableComponent> AvailableComponents { get; set; }
        public List<BillOfMaterialsCustomEntry> BillOfMaterialsCustomEntries { get; set; }
        public List<Circuit> Circuits { get; set; }
        public List<CircuitReferenceDrawing> CircuitReferenceDrawings { get; set; }
        public List<ExternalLoadCircuit> ExternalLoadCircuits { get; set; }
        public List<HeatSink> HeatSinks { get; set; }
        public List<InsulationType> InsulationTypes { get; set; }
        public List<Panel> Panels { get; set; }
        public List<PipeType> PipeTypes { get; set; }
        public List<ProcessFluid> ProcessFluids { get; set; }
        public List<ProjectCatalogPartExtraRequirement> ProjectCatalogPartExtraRequirements { get; set; }
        public List<ProjectDefaultComponent> ProjectDefaultComponents { get; set; }
        public List<ProjectDefaultMIQSpecification> ProjectDefaultMIQSpecifications { get; set; }
        public List<ProjectDefaultTagName> ProjectDefaultTagNames { get; set; }
        public List<ProjectOwner> ProjectOwners { get; set; }
        public List<SelectableCatalogPart> SelectableCatalogParts { get; set; }
    }

    public class ConnectionDetail
    {
        public string ConnectionId { get; set; }
        public string ProjectId { get; set; }
        public string CircuitId { get; set; }
        public string SegmentId { get; set; }
    }

    public class ConnectionInformation
    {
        public string ConnectionId { get; set; }
        public string ProjectId { get; set; }
    }
    public class ConnectionDescription
    {
        public string ConnectionId { get; set; }
        public string ConnectionString { get; set; }

        public ConnectionDescription(string connectionId, string connectionString)
        {
            ConnectionId = connectionId;
            ConnectionString = connectionString;
        }
    }


    public class CircuitReferenceDrawing
    {
        public Guid CircuitReferenceDrawingID { get; set; }
        public Nullable<Guid> CircuitID { get; set; }
        public string Number { get; set; }
        public Nullable<int> CircuitReferenceDrawingTypeID { get; set; }
        public string UserReferenceDrawingType { get; set; }
        public string Revision { get; set; }
        public Nullable<DateTime> Received { get; set; }
        public Nullable<Guid> ProjectID { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
        public CircuitReferenceDrawingType CircuitReferenceDrawingType { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
    }

    public class CircuitReferenceDrawingType
    {
        public int CircuitReferenceDrawingTypeID { get; set; }
        public string ReferenceDrawingTypeName { get; set; }
        public string ReferenceDrawingTypeNamePlural { get; set; }
        public bool IsVisible { get; set; }
        public List<CircuitReferenceDrawing> CircuitReferenceDrawings { get; set; }
    }

    public class BillOfMaterialsCustomEntry
    {
        public Guid BillOfMaterialsCustomEntryID { get; set; }
        public Guid ProjectID { get; set; }
        public Nullable<int> ItemNumber { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public string CatalogNumber { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
    }

    public class ProjectDefaultTagName
    {
        public Guid ProjectDefaultTagNameID { get; set; }
        public int DefaultTagFieldID { get; set; }
        public Guid ProjectID { get; set; }
        public string DefaultTagFormat { get; set; }
        public DefaultTagField DefaultTagField { get; set; } // DERIVED
        public ProjectDto Project { get; set; } // DERIVED
    }

    public class DefaultTagField
    {
        public int DefaultTagFieldID { get; set; }
        public string DefaultTagFieldName { get; set; }
        public Nullable<int> ComponentTypeID { get; set; }
        public Nullable<int> ComponentFieldID { get; set; }
        public List<ProjectDefaultTagName> ProjectDefaultTagNames { get; set; }
    }

    public class Culture
    {
        public int CultureID { get; set; }
        public string Name { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }

    public class AluminumTape
    {
        public int AluminumTapeID { get; set; }
        public string AluminumTapeName { get; set; }
        public int TapeWidth { get; set; }
        public bool ProgramSelect { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }

    public class ProjectDefaultMIQSpecification
    {
        public Guid ProjectID { get; set; }
        public Guid DefaultMIQSpecificationID { get; set; }
        public ProjectDto Project { get; set; } // DERIVED
        public DefaultMIQSpecification DefaultMIQSpecification { get; set; } // DERIVED
    }

    public class DefaultMIQSpecification
    {
        public Guid DefaultMIQSpecificationID { get; set; }
        public int MIQColdLeadSizeID { get; set; }
        public bool IsLaserWeld { get; set; }
        public bool IsPullingEye { get; set; }
        public bool IsReverseGland { get; set; }
        public bool IsGlandThreadTypeMetric { get; set; }
        public int MIQQuickDisconnectID { get; set; }
        public bool IsAttachmentMethodTieWire { get; set; }
        public string Notes { get; set; }
        public Nullable<int> MIQMethodOfProtectionID { get; set; }
        public decimal ColdLeadLength { get; set; }
        public bool IsColdLeadLengthMetric { get; set; }
        public bool IsColdLeadLengthCustom { get; set; }
        public MIQColdLeadSize MIQColdLeadSize { get; set; } // DERIVED
        public MIQQuickDisconnect MIQQuickDisconnect { get; set; } // DERIVED
        public MIQMethodOfProtection MIQMethodOfProtection { get; set; } // DERIVED
        public List<ConnectionDefaultMIQSpecification> ConnectionDefaultMIQSpecifications { get; set; }
        public List<ProjectDefaultMIQSpecification> ProjectDefaultMIQSpecifications { get; set; }
    }

    public class ConnectionDefaultMIQSpecification
    {
        public Guid ConnectionID { get; set; }
        public Guid DefaultMIQSpecificationID { get; set; }
        public Connection Connection { get; set; } // DERIVED
        public DefaultMIQSpecification DefaultMIQSpecification { get; set; } // DERIVED
    }

    public class MIQColdLeadSize
    {
        public int MIQColdLeadSizeID { get; set; }
        public int Size { get; set; }
        public bool IsDefault { get; set; }
        public List<ConnectionMIQSpecification> ConnectionMIQSpecifications { get; set; }
        public List<DefaultMIQSpecification> DefaultMIQSpecifications { get; set; }
        public List<MIQCircuitOverride> MIQCircuitOverrides { get; set; }
    }

    public class ConnectionMIQSpecification
    {
        public Guid ConnectionID { get; set; }
        public int MIQColdLeadSizeID { get; set; }
        public bool IsLaserWeld { get; set; }
        public bool IsPullingEye { get; set; }
        public bool IsReverseGland { get; set; }
        public bool IsGlandThreadTypeMetric { get; set; }
        public int MIQQuickDisconnectID { get; set; }
        public bool IsAttachmentMethodTieWire { get; set; }
        public string Notes { get; set; }
        public Nullable<int> MIQMethodOfProtectionID { get; set; }
        public decimal ColdLeadLength { get; set; }
        public bool IsColdLeadLengthMetric { get; set; }
        public bool IsColdLeadLengthCustom { get; set; }
        public Connection Connection { get; set; } // DERIVED
        public MIQColdLeadSize MIQColdLeadSize { get; set; } // DERIVED
        public MIQQuickDisconnect MIQQuickDisconnect { get; set; } // DERIVED
        public MIQMethodOfProtection MIQMethodOfProtection { get; set; } // DERIVED
        public List<ConnectionMIQUsageMarking> ConnectionMIQUsageMarkings { get; set; }
    }

    public class ConnectionMIQUsageMarking
    {
        public Guid ConnectionMIQUsageMarkingID { get; set; }
        public Guid ConnectionID { get; set; }
        public int MIQUsageMarkingID { get; set; }
        public ConnectionMIQSpecification Connection { get; set; } // DERIVED
        public MIQUsageMarking MIQUsageMarking { get; set; } // DERIVED
    }

    public class MIQUsageMarking
    {
        public int MIQUsageMarkingID { get; set; }
        public string UsageMarkingType { get; set; }
        public string UsageMarkingDescription { get; set; }
        public List<ConnectionMIQUsageMarking> ConnectionMIQUsageMarkings { get; set; }
    }

    public class MIQMethodOfProtection
    {
        public int MIQMethodOfProtectionID { get; set; }
        public string MethodOfProtectionType { get; set; }
        public List<ConnectionMIQSpecification> ConnectionMIQSpecifications { get; set; }
        public List<DefaultMIQSpecification> DefaultMIQSpecifications { get; set; }
    }

    public class MIQQuickDisconnect
    {
        public int MIQQuickDisconnectID { get; set; }
        public string QuickDisconnectType { get; set; }
        public string QuickDisconnectionDescription { get; set; }
        public List<ConnectionMIQSpecification> ConnectionMIQSpecifications { get; set; }
        public List<DefaultMIQSpecification> DefaultMIQSpecifications { get; set; }
        public List<MIQCircuitOverride> MIQCircuitOverrides { get; set; }
    }

    public class MIQCircuitOverride
    {
        public Guid MIQCircuitOverrideID { get; set; }
        public Guid CircuitID { get; set; }
        public double SegmentLength { get; set; }
        public string MIQColdLeadType { get; set; }
        public string TagNumber { get; set; }
        public Nullable<int> MIQColdLeadLengthID { get; set; }
        public Nullable<int> MIQColdLeadSizeID { get; set; }
        public Nullable<double> MIQQuickDisconnectLength { get; set; }
        public Nullable<int> MIQQuickDisconnectID { get; set; }
        public Circuit Circuit { get; set; } // DERIVED
        public MIQColdLeadLength MIQColdLeadLength { get; set; } // DERIVED
        public MIQColdLeadSize MIQColdLeadSize { get; set; } // DERIVED
        public MIQQuickDisconnect MIQQuickDisconnect { get; set; } // DERIVED
    }

    public class MIQColdLeadLength
    {
        public int MIQColdLeadLengthID { get; set; }
        public decimal Length { get; set; }
        public bool IsMetric { get; set; }
        public bool IsDefault { get; set; }
        public List<MIQCircuitOverride> MIQCircuitOverrides { get; set; }
    }

    public class CircumferentialFixingTape
    {
        public int CircumferentialFixingTapeID { get; set; }
        public string CircumferentialFixingTapeName { get; set; }
        public bool ProgramSelect { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }

    public class Segment
    {
        public Guid SegmentID { get; set; }
        public Guid ConnectionID { get; set; }
        public Guid NodeStartID { get; set; }
        public Guid NodeEndID { get; set; }
        public string SegmentName { get; set; }
        public Guid PipeSizeID { get; set; }
        public double PipeLength { get; set; }
        public Guid PipeTouchingInsulationTypeID { get; set; }
        public Guid PipeTouchingInsulationDimensionID { get; set; }
        public Nullable<Guid> NonPipeTouchingInsulationTypeID { get; set; }
        public Nullable<Guid> NonPipeTouchingInsulationDimensionID { get; set; }
        public int InsulationSizeID { get; set; }
        public int WeatherBarrierID { get; set; }
        public Nullable<int> CableID { get; set; }
        public Nullable<int> SafetyFactor { get; set; }
        public Nullable<double> Overvoltage { get; set; }
        public Nullable<double> TerminationAllowance { get; set; }
        public Nullable<double> MiscAllowance { get; set; }
        public Nullable<int> AdditionalPowerRequired { get; set; }
        public bool IsTemperatureSensingSegment { get; set; }
        public bool IsCableUserSelected { get; set; }
        public string Module { get; set; }
        public string WorkPackage { get; set; }
        public string Area { get; set; }
        public string CustomerLineNumber { get; set; }
        public string TagNumber { get; set; }
        public int SegmentOrder { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public string DrawingNumber { get; set; }
        public string DrawingRevision { get; set; }
        public Nullable<int> DrawingSheet { get; set; }
        public Nullable<int> DrawingSheets { get; set; }
        public string CustomerDrawingNumber { get; set; }
        public Nullable<DateTime> DrawingDataImported { get; set; }
        public Guid PipeTypeID { get; set; }
        public string SegmentComment { get; set; }
        public double ConstructionAllowance { get; set; }
        public Connection Connection { get; set; } // DERIVED
        public Node NodeStart { get; set; } // DERIVED
        public Node NodeEnd { get; set; } // DERIVED
        public PipeSize PipeSize { get; set; } // DERIVED
        public InsulationType PipeTouchingInsulationType { get; set; } // DERIVED
        public InsulationDimension PipeTouchingInsulationDimension { get; set; } // DERIVED
        public InsulationType NonPipeTouchingInsulationType { get; set; } // DERIVED
        public InsulationDimension NonPipeTouchingInsulationDimension { get; set; } // DERIVED
        public InsulationSize InsulationSize { get; set; } // DERIVED
        public WeatherBarrier WeatherBarrier { get; set; } // DERIVED
        public Cable Cable { get; set; } // DERIVED
        public PipeType PipeType { get; set; } // DERIVED
        public List<Node> Nodes { get; set; } // DERIVED
        public List<InsulationType> InsulationTypes { get; set; } // DERIVED
        public List<InsulationDimension> InsulationDimensions { get; set; } // DERIVED
        public List<BillOfMaterialsEntry> BillOfMaterialsEntries { get; set; }
        public List<BillOfMaterialsSpecialEntry> BillOfMaterialsSpecialEntries { get; set; }
        public List<DesignSegment> DesignSegments { get; set; }
        public List<SegmentHeatSink> SegmentHeatSinks { get; set; }
        public List<SegmentReference> SegmentReferences { get; set; }
    }

    public class SegmentReference
    {
        public Guid SegmentReferenceID { get; set; }
        public Guid SegmentID { get; set; }
        public string ReferenceNumber { get; set; }
        public Segment Segment { get; set; } // DERIVED
    }

    public class WeatherBarrier
    {
        public int WeatherBarrierID { get; set; }
        public string WeatherBarrierName { get; set; }
        public double Emissivity { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class InsulationSize
    {
        public int InsulationSizeID { get; set; }
        public string InsulationSizeName { get; set; }
        public List<Segment> Segments { get; set; }
    }

    public class BillOfMaterialsSpecialEntry
    {
        public Guid BillOfMaterialsSpecialEntryID { get; set; }
        public Guid SegmentID { get; set; }
        public Nullable<int> ItemNumber { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public string CatalogNumber { get; set; }
        public bool SystemDefined { get; set; }
        public bool CustomConnector { get; set; }
        public Segment Segment { get; set; } // DERIVED
    }

    public class Node
    {
        public Guid NodeID { get; set; }
        public int NodeTypeID { get; set; }
        public double XLocation { get; set; }
        public double YLocation { get; set; }
        public NodeType NodeType { get; set; } // DERIVED
        public List<Segment> Segments { get; set; }
    }

    public class NodeType
    {
        public int NodeTypeID { get; set; }
        public string NodeTypeName { get; set; }
        public string Description { get; set; }
        public int InSegments { get; set; }
        public int OutSegments { get; set; }
        public List<Node> Nodes { get; set; }
    }


}
