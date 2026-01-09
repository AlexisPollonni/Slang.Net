namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion"]/*' />
[NativeTypeName("unsigned int")]
public enum SlangLanguageVersion : uint
{
    /// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion.SLANG_LANGUAGE_VERSION_UNKNOWN"]/*' />
    SLANG_LANGUAGE_VERSION_UNKNOWN = 0,

    /// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion.SLANG_LANGUAGE_VERSION_LEGACY"]/*' />
    SLANG_LANGUAGE_VERSION_LEGACY = 2018,

    /// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion.SLANG_LANGUAGE_VERSION_2025"]/*' />
    SLANG_LANGUAGE_VERSION_2025 = 2025,

    /// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion.SLANG_LANGUAGE_VERSION_2026"]/*' />
    SLANG_LANGUAGE_VERSION_2026 = 2026,

    /// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion.SLANG_LANGAUGE_VERSION_DEFAULT"]/*' />
    SLANG_LANGAUGE_VERSION_DEFAULT = SLANG_LANGUAGE_VERSION_LEGACY,

    /// <include file='SlangLanguageVersion.xml' path='doc/member[@name="SlangLanguageVersion.SLANG_LANGUAGE_VERSION_LATEST"]/*' />
    SLANG_LANGUAGE_VERSION_LATEST = SLANG_LANGUAGE_VERSION_2026,
}
