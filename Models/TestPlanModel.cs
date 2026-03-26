
public class TestPlanDto
{
    public string schemaVersion { get; set; }
    public string planVersion { get; set; }
    public string planId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public DateTime publishedAt { get; set; }
    public string publishedBy { get; set; }
    public string checksum { get; set; }
    public string signature { get; set; }
    public Product product { get; set; }
    public Capabilities capabilities { get; set; }
    public Executionpolicy executionPolicy { get; set; }
    public Stationpolicy stationPolicy { get; set; }
    public Resultpolicy resultPolicy { get; set; }
    public Identification identification { get; set; }
    public Environment environment { get; set; }
    public Thresholdprofiles thresholdProfiles { get; set; }
    public Step[] steps { get; set; }
    public Finaldecisionpolicy finalDecisionPolicy { get; set; }
    public Offlinepolicy offlinePolicy { get; set; }
    public Audit audit { get; set; }
}

public class Product
{
    public string modelId { get; set; }
    public string sku { get; set; }
    public string family { get; set; }
    public int androidMinVersion { get; set; }
    public Firmwareconstraint firmwareConstraint { get; set; }
}

public class Firmwareconstraint
{
    public string minBuildFingerprint { get; set; }
    public string[] allowedBuildTags { get; set; }
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
    public string mode { get; set; }
    public bool allowOperatorSkip { get; set; }
    public bool allowManualOverride { get; set; }
    public bool stopOnCriticalFailure { get; set; }
    public bool persistAfterEachStep { get; set; }
    public bool resumeInterruptedExecution { get; set; }
    public int maxExecutionTimeSec { get; set; }
}

public class Stationpolicy
{
    public string stationType { get; set; }
    public bool requiredStationId { get; set; }
    public bool requiredOperatorLogin { get; set; }
    public bool requiredPalletBind { get; set; }
    public string[] bindKeys { get; set; }
}

public class Resultpolicy
{
    public string uploadMode { get; set; }
    public string idempotencyKeyMode { get; set; }
    public bool storeTechnicalLogs { get; set; }
    public bool storeStepMetrics { get; set; }
    public bool storeEvidence { get; set; }
}

public class Identification
{
    public Serialnumber serialNumber { get; set; }
    public Imei imei { get; set; }
}

public class Serialnumber
{
    public bool required { get; set; }
    public string source { get; set; }
    public string pattern { get; set; }
}

public class Imei
{
    public bool required { get; set; }
    public string source { get; set; }
    public Validation validation { get; set; }
}

public class Validation
{
    public int length { get; set; }
    public bool luhn { get; set; }
}

public class Environment
{
    public Wifi wifi { get; set; }
    public Bluetooth bluetooth { get; set; }
    public Gps gps { get; set; }
}

public class Wifi
{
    public string targetSsid { get; set; }
    public string security { get; set; }
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
    public Audio audio { get; set; }
    public Camera camera { get; set; }
}

public class Audio
{
    public Speaker speaker { get; set; }
    public Receiver receiver { get; set; }
    public Microphone microphone { get; set; }
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
    public Rear rear { get; set; }
    public Front front { get; set; }
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
    public Passif passIf { get; set; }
    public Failif failIf { get; set; }
    public Ngclassification ngClassification { get; set; }
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
    public string criticalFailure { get; set; }
    public string nonCriticalFailure { get; set; }
}

public class Offlinepolicy
{
    public bool enabled { get; set; }
    public bool localQueueEnabled { get; set; }
    public int maxPendingExecutions { get; set; }
    public Retrypolicy retryPolicy { get; set; }
}

public class Retrypolicy
{
    public string strategy { get; set; }
    public int maxRetries { get; set; }
    public int initialDelayMs { get; set; }
    public int maxDelayMs { get; set; }
}

public class Audit
{
    public bool requirePublicationAudit { get; set; }
    public string[] fieldsTracked { get; set; }
}

public class Step
{
    public string stepId { get; set; }
    public int order { get; set; }
    public string testId { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string group { get; set; }
    public bool critical { get; set; }
    public bool enabled { get; set; }
    public int timeoutSec { get; set; }
    public int retries { get; set; }
    public string[] capabilityRequired { get; set; }
    public Passcriteria passCriteria { get; set; }
    public Params _params { get; set; }
    public Onfail onFail { get; set; }
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
    public string targetSsid { get; set; }
    public bool recordIpAddress { get; set; }
    public int scanTimeoutSec { get; set; }
    public int minRelativeRssiDbm { get; set; }
    public string[] acceptedStates { get; set; }
    public int warmupSec { get; set; }
    public int expectedRamMb { get; set; }
    public int expectedStorageGb { get; set; }
    public string cpuFamily { get; set; }
    public bool collectBatteryHealth { get; set; }
    public bool collectBatteryLevel { get; set; }
    public int toneFrequencyHz { get; set; }
    public int toneDurationMs { get; set; }
    public int fftWindowSize { get; set; }
    public bool useLoopback { get; set; }
    public string cameraLens { get; set; }
    public int captureCount { get; set; }
    public bool useChartComparison { get; set; }
    public bool showOperatorSummary { get; set; }
    public bool generateExecutionHash { get; set; }
}

public class Onfail
{
    public string action { get; set; }
    public string resultCode { get; set; }
}
