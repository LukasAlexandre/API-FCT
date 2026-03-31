using System.Text.Json;
using System.Text.Json.Serialization;
public class TestPlanDto
{
    public required string schemaVersion { get; set; }
    public required string planVersion { get; set; }
    public required string planId { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required string status { get; set; }
    public DateTime publishedAt { get; set; }
    public required string publishedBy { get; set; }
    public required string checksum { get; set; }
    public required string signature { get; set; }
    public required Product product { get; set; }
    public required Capabilities capabilities { get; set; }
    public required Executionpolicy executionPolicy { get; set; }
    public required Stationpolicy stationPolicy { get; set; }
    public required Resultpolicy resultPolicy { get; set; }
    public required Identification identification { get; set; }
    public required TestEnvironment Environment { get; set; }
    public required Thresholdprofiles thresholdProfiles { get; set; }
    public required Step[] steps { get; set; }
    public required Finaldecisionpolicy finalDecisionPolicy { get; set; }
    public required Offlinepolicy offlinePolicy { get; set; }
    public required Audit audit { get; set; }
}

public class Product
{
    public required string modelId { get; set; }
    public required string sku { get; set; }
    public required string family { get; set; }
    public int androidMinVersion { get; set; }
    public required Firmwareconstraint firmwareConstraint { get; set; }
}

public class Firmwareconstraint
{
    public required string minBuildFingerprint { get; set; }
    public required string[] allowedBuildTags { get; set; }
}

public class Capabilities
{
    public bool hasTelephony { get; set; }
    public bool hasImei { get; set; }
    public bool hasSim { get; set; }
    public bool hasSdCard { get; set; }
    public bool hasGps { get; set; }
    public bool hasBluetooth { get; set; }
    public bool hasWifi { get; set; }
    public bool hasFrontCamera { get; set; }
    public bool hasRearCamera { get; set; }
    public bool hasReceiver { get; set; }
    public bool hasSpeaker { get; set; }
    public bool hasMic { get; set; }
    public bool hasUsbC { get; set; }
    public bool hasP2 { get; set; }
    public bool hasBattery { get; set; }
}

public class Executionpolicy
{
    public required string mode { get; set; }
    public bool allowOperatorSkip { get; set; }
    public bool allowManualOverride { get; set; }
    public bool stopOnCriticalFailure { get; set; }
    public bool persistAfterEachStep { get; set; }
    public bool resumeInterruptedExecution { get; set; }
    public int maxExecutionTimeSec { get; set; }
}

public class Stationpolicy
{
    public required string stationType { get; set; }
    public bool requiredStationId { get; set; }
    public bool requiredOperatorLogin { get; set; }
    public bool requiredPalletBind { get; set; }
    public required string[] bindKeys { get; set; }
}

public class Resultpolicy
{
    public required string uploadMode { get; set; }
    public required string idempotencyKeyMode { get; set; }
    public bool storeTechnicalLogs { get; set; }
    public bool storeStepMetrics { get; set; }
    public bool storeEvidence { get; set; }
}

public class Identification
{
    public required Serialnumber serialNumber { get; set; }
    public required Imei imei { get; set; }
}

public class Serialnumber
{
    public bool required { get; set; }
    public required string source { get; set; }
    public required string pattern { get; set; }
}

public class Imei
{
    public bool required { get; set; }
    public required string source { get; set; }
    public required Validation validation { get; set; }
}

public class Validation
{
    public int length { get; set; }
    public bool luhn { get; set; }
}

public class TestEnvironment
{
    public required Wifi wifi { get; set; }
    public required Bluetooth bluetooth { get; set; }
    public required Gps gps { get; set; }
}

public class Wifi
{
    public required string targetSsid { get; set; }
    public required string security { get; set; }
    public int minRssiDbm { get; set; }
    public int stabilityWindowSec { get; set; }
}

public class Bluetooth
{
    public int scanTimeoutSec { get; set; }
    public int minDevicesFound { get; set; }
    public int minRelativeRssiDbm { get; set; }
}

public class Gps
{
    public int maxFixTimeSec { get; set; }
    public int minSatellites { get; set; }
    public float minAccuracyMeters { get; set; }
}

public class Thresholdprofiles
{
    public required Audio audio { get; set; }
    public required Camera camera { get; set; }
}

public class Audio
{
    public required Speaker speaker { get; set; }
    public required Receiver receiver { get; set; }
    public required Microphone microphone { get; set; }
}

public class Speaker
{
    public float minPeakDb { get; set; }
    public float maxNoiseFloorDb { get; set; }
    public int expectedFreqHz { get; set; }
    public int toleranceHz { get; set; }
}

public class Receiver
{
    public float minPeakDb { get; set; }
    public float maxNoiseFloorDb { get; set; }
    public int expectedFreqHz { get; set; }
    public int toleranceHz { get; set; }
}

public class Microphone
{
    public float minCapturedDb { get; set; }
    public float maxClippingPercent { get; set; }
}

public class Camera
{
    public required Rear rear { get; set; }
    public required Front front { get; set; }
}

public class Rear
{
    public float minBlurScore { get; set; }
    public float minBrightness { get; set; }
    public float maxBrightness { get; set; }
    public bool chartRequired { get; set; }
    public float minSsim { get; set; }
}

public class Front
{
    public float minBlurScore { get; set; }
    public float minBrightness { get; set; }
    public float maxBrightness { get; set; }
    public bool chartRequired { get; set; }
}

public class Finaldecisionpolicy
{
    public required Passif passIf { get; set; }
    public required Failif failIf { get; set; }
    public required Ngclassification ngClassification { get; set; }
}

public class Passif
{
    public bool allCriticalStepsPassed { get; set; }
}

public class Failif
{
    public bool anyCriticalStepFailed { get; set; }
}

public class Ngclassification
{
    public required string criticalFailure { get; set; }
    public required string nonCriticalFailure { get; set; }
}

public class Offlinepolicy
{
    public bool enabled { get; set; }
    public bool localQueueEnabled { get; set; }
    public int maxPendingExecutions { get; set; }
    public required Retrypolicy retryPolicy { get; set; }
}

public class Retrypolicy
{
    public required string strategy { get; set; }
    public int maxRetries { get; set; }
    public int initialDelayMs { get; set; }
    public int maxDelayMs { get; set; }
}

public class Audit
{
    public bool requirePublicationAudit { get; set; }
    public required string[] fieldsTracked { get; set; }
}

public class Step
{
    public required string stepId { get; set; }
    public int order { get; set; }
    public required string testId { get; set; }
    public required string name { get; set; }
    public required string type { get; set; }
    public required string group { get; set; }
    public bool critical { get; set; }
    public bool enabled { get; set; }
    public int timeoutSec { get; set; }
    public int retries { get; set; }
    public required string[] capabilityRequired { get; set; }


 
    public JsonElement passCriteria { get; set; }

    public JsonElement  @params { get; set; }
    public required Onfail onFail { get; set; }
}

public class Passcriteria
{
    public bool serialNumberRequired { get; set; }
    public bool imeiRequired { get; set; }
    public bool modelMatchRequired { get; set; }
    public bool mustConnectToTargetSsid { get; set; }
    public int minRssiDbm { get; set; }
    public int stabilityWindowSec { get; set; }
    public int minDevicesFound { get; set; }
    public bool simMustBePresent { get; set; }
    public int maxFixTimeSec { get; set; }
    public int minSatellites { get; set; }
    public float minAccuracyMeters { get; set; }
    public bool mustMatchRecipe { get; set; }
    public bool batteryPresent { get; set; }
    public bool usbAttached { get; set; }
    public bool chargingDetected { get; set; }
    public float batteryTempMaxC { get; set; }
    public float speakerMinPeakDb { get; set; }
    public float micMinCapturedDb { get; set; }
    public float minBlurScore { get; set; }
    public bool chartRequired { get; set; }
    public float minSsim { get; set; }
    public bool allCriticalTestsMustPass { get; set; }
}

public class Params
{
    public bool collectBuildInfo { get; set; }
    public bool collectAndroidVersion { get; set; }
    public bool collectDeviceFingerprint { get; set; }
    public required string targetSsid { get; set; }
    public bool recordIpAddress { get; set; }
    public int scanTimeoutSec { get; set; }
    public int minRelativeRssiDbm { get; set; }
    public required string[] acceptedStates { get; set; }
    public int warmupSec { get; set; }
    public int expectedRamMb { get; set; }
    public int expectedStorageGb { get; set; }
    public required string cpuFamily { get; set; }
    public bool collectBatteryHealth { get; set; }
    public bool collectBatteryLevel { get; set; }
    public int toneFrequencyHz { get; set; }
    public int toneDurationMs { get; set; }
    public int fftWindowSize { get; set; }
    public bool useLoopback { get; set; }
    public required string cameraLens { get; set; }
    public int captureCount { get; set; }
    public bool useChartComparison { get; set; }
    public bool showOperatorSummary { get; set; }
    public bool generateExecutionHash { get; set; }
}

public class Onfail
{
    public required string action { get; set; }
    public required string resultCode { get; set; }
}
