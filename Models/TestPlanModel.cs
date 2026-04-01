using System.Text.Json;
using System.Text.Json.Serialization;
public class TestPlanDto
{
    public required string SchemaVersion { get; set; }
    public required string PlanVersion { get; set; }
    public required string PlanId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public DateTime PublishedAt { get; set; }
    public required string PublishedBy { get; set; }
    public required string Checksum { get; set; }
    public required string Signature { get; set; }
    public required Product Product { get; set; }
    public required Capabilities Capabilities { get; set; }
    public required ExecutionPolicy ExecutionPolicy { get; set; }
    public required StationPolicy StationPolicy { get; set; }
    public required ResultPolicy ResultPolicy { get; set; }
    public required Identification Identification { get; set; }
    public required TestEnvironment Environment { get; set; }
    public required ThresholdProfiles ThresholdProfiles { get; set; }
    public required Step[] Steps { get; set; }
    public required FinalDecisionPolicy FinalDecisionPolicy { get; set; }
    public required OfflinePolicy OfflinePolicy { get; set; }
    public required Audit Audit { get; set; }
}

public class Product
{
    public required string ModelId { get; set; }
    public required string Sku { get; set; }
    public required string Family { get; set; }
    public int AndroidMinVersion { get; set; }
    public required FirmwareConstraint FirmwareConstraint { get; set; }
}

public class FirmwareConstraint
{
    public required string MinBuildFingerprint { get; set; }
    public required string[] AllowedBuildTags { get; set; }
}

public class Capabilities
{
    public bool HasTelephony { get; set; }
    public bool HasImei { get; set; }
    public bool HasSim { get; set; }
    public bool HasSdCard { get; set; }
    public bool HasGps { get; set; }
    public bool HasBluetooth { get; set; }
    public bool HasWifi { get; set; }
    public bool HasFrontCamera { get; set; }
    public bool HasRearCamera { get; set; }
    public bool HasReceiver { get; set; }
    public bool HasSpeaker { get; set; }
    public bool HasMic { get; set; }
    public bool HasUsbC { get; set; }
    public bool HasP2 { get; set; }
    public bool HasBattery { get; set; }
}

public class ExecutionPolicy
{
    public required string Mode { get; set; }
    public bool AllowOperatorSkip { get; set; }
    public bool AllowManualOverride { get; set; }
    public bool StopOnCriticalFailure { get; set; }
    public bool PersistAfterEachStep { get; set; }
    public bool ResumeInterruptedExecution { get; set; }
    public int MaxExecutionTimeSec { get; set; }
}

public class StationPolicy
{
    public required string StationType { get; set; }
    public bool RequiredStationId { get; set; }
    public bool RequiredOperatorLogin { get; set; }
    public bool RequiredPalletBind { get; set; }
    public required string[] BindKeys { get; set; }
}

public class ResultPolicy
{
    public required string UploadMode { get; set; }
    public required string IdempotencyKeyMode { get; set; }
    public bool StoreTechnicalLogs { get; set; }
    public bool StoreStepMetrics { get; set; }
    public bool StoreEvidence { get; set; }
}

public class Identification
{
    public required SerialNumber SerialNumber { get; set; }
    public required Imei Imei { get; set; }
}

public class SerialNumber
{
    public bool Required { get; set; }
    public required string Source { get; set; }
    public required string Pattern { get; set; }
}

public class Imei
{
    public bool Required { get; set; }
    public required string Source { get; set; }
    public required Validation Validation { get; set; }
}

public class Validation
{
    public int Length { get; set; }
    public bool Luhn { get; set; }
}

public class TestEnvironment
{
    public required Wifi Wifi { get; set; }
    public required Bluetooth Bluetooth { get; set; }
    public required Gps Gps { get; set; }
}

public class Wifi
{
    public required string TargetSsid { get; set; }
    public required string Security { get; set; }
    public int MinRssiDbm { get; set; }
    public int StabilityWindowSec { get; set; }
}

public class Bluetooth
{
    public int ScanTimeoutSec { get; set; }
    public int MinDevicesFound { get; set; }
    public int MinRelativeRssiDbm { get; set; }
}

public class Gps
{
    public int MaxFixTimeSec { get; set; }
    public int MinSatellites { get; set; }
    public float MinAccuracyMeters { get; set; }
}

public class ThresholdProfiles
{
    public required Audio Audio { get; set; }
    public required Camera Camera { get; set; }
}

public class Audio
{
    public required Speaker Speaker { get; set; }
    public required Receiver Receiver { get; set; }
    public required Microphone Microphone { get; set; }
}

public class Speaker
{
    public float MinPeakDb { get; set; }
    public float MaxNoiseFloorDb { get; set; }
    public int ExpectedFreqHz { get; set; }
    public int ToleranceHz { get; set; }
}

public class Receiver
{
    public float MinPeakDb { get; set; }
    public float MaxNoiseFloorDb { get; set; }
    public int ExpectedFreqHz { get; set; }
    public int ToleranceHz { get; set; }
}

public class Microphone
{
    public float MinCapturedDb { get; set; }
    public float MaxClippingPercent { get; set; }
}

public class Camera
{
    public required Rear Rear { get; set; }
    public required Front Front { get; set; }
}

public class Rear
{
    public float MinBlurScore { get; set; }
    public float MinBrightness { get; set; }
    public float MaxBrightness { get; set; }
    public bool ChartRequired { get; set; }
    public float WinSsim { get; set; }
}

public class Front
{
    public float MinBlurScore { get; set; }
    public float MinBrightness { get; set; }
    public float MaxBrightness { get; set; }
    public bool ChartRequired { get; set; }
}

public class FinalDecisionPolicy
{
    public required PassIf PassIf { get; set; }
    public required FailIf FailIf { get; set; }
    public required NgClassification NgClassification { get; set; }
}

public class PassIf
{
    public bool AllCriticalStepsPassed { get; set; }
}

public class FailIf
{
    public bool AnyCriticalStepFailed { get; set; }
}

public class NgClassification
{
    public required string CriticalFailure { get; set; }
    public required string NonCriticalFailure { get; set; }
}

public class OfflinePolicy
{
    public bool Enabled { get; set; }
    public bool LocalQueueEnabled { get; set; }
    public int MaxPendingExecutions { get; set; }
    public required RetryPolicy RetryPolicy { get; set; }
}

public class RetryPolicy
{
    public required string Strategy { get; set; }
    public int MaxRetries { get; set; }
    public int InitialDelayMs { get; set; }
    public int MaxDelayMs { get; set; }
}

public class Audit
{
    public bool RequirePublicationAudit { get; set; }
    public required string[] FieldsTracked { get; set; }
}

public class Step
{
    public required string StepId { get; set; }
    public int Order { get; set; }
    public required string TestId { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Group { get; set; }
    public bool Critical { get; set; }
    public bool Enabled { get; set; }
    public int TimeoutSec { get; set; }
    public int Retries { get; set; }
    public required string[] CapabilityRequired { get; set; }


 
    public JsonElement PassCriteria { get; set; }

    [JsonPropertyName("params")]
    public JsonElement StepParams { get; set; }
    public required OnFail OnFail { get; set; }
}

public class PassCriteria
{
    public bool SerialNumberRequired { get; set; }
    public bool ImeiRequired { get; set; }
    public bool ModelMatchRequired { get; set; }
    public bool MustConnectToTargetSsid { get; set; }
    public int MinRssiDbm { get; set; }
    public int StabilityWindowSec { get; set; }
    public int MinDevicesFound { get; set; }
    public bool SimMustBePresent { get; set; }
    public int MaxFixTimeSec { get; set; }
    public int MinSatellites { get; set; }
    public float MinAccuracyMeters { get; set; }
    public bool MustMatchRecipe { get; set; }
    public bool BatteryPresent { get; set; }
    public bool UsbAttached { get; set; }
    public bool ChargingDetected { get; set; }
    public float BatteryTempMaxC { get; set; }
    public float SpeakerMinPeakDb { get; set; }
    public float MicMinCapturedDb { get; set; }
    public float MinBlurScore { get; set; }
    public bool ChartRequired { get; set; }
    public float MinSsim { get; set; }
    public bool AllCriticalTestsMustPass { get; set; }
}

public class Params
{
    public bool CollectBuildInfo { get; set; }
    public bool CollectAndroidVersion { get; set; }
    public bool CollectDeviceFingerprint { get; set; }
    public required string TargetSsid { get; set; }
    public bool RecordIpAddress { get; set; }
    public int ScanTimeoutSec { get; set; }
    public int MinRelativeRssiDbm { get; set; }
    public required string[] AcceptedStates { get; set; }
    public int WarmupSec { get; set; }
    public int ExpectedRamMb { get; set; }
    public int ExpectedStorageGb { get; set; }
    public required string CpuFamily { get; set; }
    public bool CollectBatteryHealth { get; set; }
    public bool CollectBatteryLevel { get; set; }
    public int ToneFrequencyHz { get; set; }
    public int ToneDurationMs { get; set; }
    public int FftWindowSize { get; set; }
    public bool UseLoopback { get; set; }
    public required string CameraLens { get; set; }
    public int CaptureCount { get; set; }
    public bool UseChartComparison { get; set; }
    public bool ShowOperatorSummary { get; set; }
    public bool GenerateExecutionHash { get; set; }
}

public class OnFail
{
    public required string Action { get; set; }
    public required string ResultCode { get; set; }
}
