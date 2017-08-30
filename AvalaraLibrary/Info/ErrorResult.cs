﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Helper function for throwing known error response
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Information about the error(s)
        /// </summary>
        public ErrorInfo error { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }

    /// <summary>
    /// Information about the error that occurred
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Type of error that occurred
        /// </summary>
        public ErrorCodeId? code { get; set; }

        /// <summary>
        /// Short one-line message to summaryize what went wrong
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// What object or service caused the error?
        /// </summary>
        public ErrorTargetCode? target { get; set; }

        /// <summary>
        /// Array of detailed error messages
        /// </summary>
        public List<ErrorDetail> details { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
    /// <summary>
    /// Represents a error code message
    /// </summary>
    public enum ErrorCodeId
    {
        /// <summary>
        /// Server has a configuration or setup problem
        /// </summary>
        ServerConfiguration,

        /// <summary>
        /// User doesn't have rights to this account or company
        /// </summary>
        AccountInvalidException,

        /// <summary>
        /// 
        /// </summary>
        CompanyInvalidException,

        /// <summary>
        /// Use this error message when the user is trying to fetch a single object and the object either does not exist or cannot be seen by the current user.
        /// </summary>
        EntityNotFoundError,

        /// <summary>
        /// 
        /// </summary>
        ValueRequiredError,

        /// <summary>
        /// 
        /// </summary>
        RangeError,

        /// <summary>
        /// 
        /// </summary>
        RangeCompareError,

        /// <summary>
        /// 
        /// </summary>
        RangeSetError,

        /// <summary>
        /// 
        /// </summary>
        TaxpayerNumberRequired,

        /// <summary>
        /// 
        /// </summary>
        CommonPassword,

        /// <summary>
        /// 
        /// </summary>
        WeakPassword,

        /// <summary>
        /// 
        /// </summary>
        StringLengthError,

        /// <summary>
        /// 
        /// </summary>
        EmailValidationError,

        /// <summary>
        /// 
        /// </summary>
        EmailMissingError,

        /// <summary>
        /// 
        /// </summary>
        ParserFieldNameError,

        /// <summary>
        /// 
        /// </summary>
        ParserFieldValueError,

        /// <summary>
        /// 
        /// </summary>
        ParserSyntaxError,

        /// <summary>
        /// 
        /// </summary>
        ParserTooManyParametersError,

        /// <summary>
        /// 
        /// </summary>
        ParserUnterminatedValueError,

        /// <summary>
        /// 
        /// </summary>
        DeleteUserSelfError,

        /// <summary>
        /// 
        /// </summary>
        OldPasswordInvalid,

        /// <summary>
        /// 
        /// </summary>
        CannotChangePassword,

        /// <summary>
        /// 
        /// </summary>
        CannotChangeCompanyCode,

        /// <summary>
        /// 
        /// </summary>
        DateFormatError,

        /// <summary>
        /// 
        /// </summary>
        NoDefaultCompany,

        /// <summary>
        /// 
        /// </summary>
        AuthenticationException,

        /// <summary>
        /// 
        /// </summary>
        AuthorizationException,

        /// <summary>
        /// 
        /// </summary>
        ValidationException,

        /// <summary>
        /// 
        /// </summary>
        InactiveUserError,

        /// <summary>
        /// 
        /// </summary>
        AuthenticationIncomplete,

        /// <summary>
        /// 
        /// </summary>
        BasicAuthIncorrect,

        /// <summary>
        /// 
        /// </summary>
        IdentityServerError,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenInvalid,

        /// <summary>
        /// 
        /// </summary>
        ModelRequiredException,

        /// <summary>
        /// 
        /// </summary>
        AccountExpiredException,

        /// <summary>
        /// 
        /// </summary>
        VisibilityError,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenNotSupported,

        /// <summary>
        /// 
        /// </summary>
        InvalidSecurityRole,

        /// <summary>
        /// 
        /// </summary>
        InvalidRegistrarAction,

        /// <summary>
        /// 
        /// </summary>
        RemoteServerError,

        /// <summary>
        /// 
        /// </summary>
        NoFilterCriteriaException,

        /// <summary>
        /// 
        /// </summary>
        OpenClauseException,

        /// <summary>
        /// 
        /// </summary>
        JsonFormatError,

        /// <summary>
        /// 
        /// </summary>
        UnhandledException,

        /// <summary>
        /// 
        /// </summary>
        ReportingCompanyMustHaveContactsError,

        /// <summary>
        /// 
        /// </summary>
        CompanyProfileNotSet,

        /// <summary>
        /// 
        /// </summary>
        CannotAssignUserToCompany,

        /// <summary>
        /// 
        /// </summary>
        MustAssignUserToCompany,

        /// <summary>
        /// 
        /// </summary>
        ModelStateInvalid,

        /// <summary>
        /// 
        /// </summary>
        DateRangeError,

        /// <summary>
        /// 
        /// </summary>
        InvalidDateRangeError,

        /// <summary>
        /// 
        /// </summary>
        DeleteInformation,

        /// <summary>
        /// 
        /// </summary>
        CannotCreateDeletedObjects,

        /// <summary>
        /// 
        /// </summary>
        CannotModifyDeletedObjects,

        /// <summary>
        /// 
        /// </summary>
        ReturnNameNotFound,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTypeAndCategory,

        /// <summary>
        /// 
        /// </summary>
        DefaultCompanyLocation,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountry,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountryRegion,

        /// <summary>
        /// 
        /// </summary>
        BrazilValidationError,

        /// <summary>
        /// 
        /// </summary>
        BrazilExemptValidationError,

        /// <summary>
        /// 
        /// </summary>
        BrazilPisCofinsError,

        /// <summary>
        /// 
        /// </summary>
        JurisdictionNotFoundError,

        /// <summary>
        /// 
        /// </summary>
        MedicalExciseError,

        /// <summary>
        /// 
        /// </summary>
        RateDependsTaxabilityError,

        /// <summary>
        /// 
        /// </summary>
        RateDependsEuropeError,

        /// <summary>
        /// 
        /// </summary>
        InvalidRateTypeCode,

        /// <summary>
        /// 
        /// </summary>
        RateTypeNotSupported,

        /// <summary>
        /// 
        /// </summary>
        CannotUpdateNestedObjects,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeInvalidChars,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeInvalidLength,

        /// <summary>
        /// 
        /// </summary>
        IncorrectPathError,

        /// <summary>
        /// 
        /// </summary>
        InvalidJurisdictionType,

        /// <summary>
        /// 
        /// </summary>
        MustConfirmResetLicenseKey,

        /// <summary>
        /// 
        /// </summary>
        DuplicateCompanyCode,

        /// <summary>
        /// 
        /// </summary>
        TINFormatError,

        /// <summary>
        /// 
        /// </summary>
        DuplicateNexusError,

        /// <summary>
        /// 
        /// </summary>
        UnknownNexusError,

        /// <summary>
        /// 
        /// </summary>
        ParentNexusNotFound,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxCodeType,

        /// <summary>
        /// 
        /// </summary>
        CannotActivateCompany,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEntityProperty,

        /// <summary>
        /// 
        /// </summary>
        ReportingEntityError,

        /// <summary>
        /// 
        /// </summary>
        InvalidReturnOperationError,

        /// <summary>
        /// 
        /// </summary>
        CannotDeleteCompany,

        /// <summary>
        /// 
        /// </summary>
        CountryOverridesNotAvailable,

        /// <summary>
        /// 
        /// </summary>
        JurisdictionOverrideMismatch,

        /// <summary>
        /// 
        /// </summary>
        DuplicateSystemTaxCode,

        /// <summary>
        /// 
        /// </summary>
        SSTOverridesNotAvailable,

        /// <summary>
        /// 
        /// </summary>
        NexusDateMismatch,

        /// <summary>
        /// 
        /// </summary>
        TechSupportAuditRequired,

        /// <summary>
        /// 
        /// </summary>
        NexusParentDateMismatch,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenParseUserIdError,

        /// <summary>
        /// 
        /// </summary>
        RetrieveUserError,

        /// <summary>
        /// 
        /// </summary>
        InvalidConfigurationSetting,

        /// <summary>
        /// 
        /// </summary>
        InvalidConfigurationValue,

        /// <summary>
        /// 
        /// </summary>
        InvalidEnumValue,

        /// <summary>
        /// 
        /// </summary>
        TaxCodeAssociatedTaxRule,

        /// <summary>
        /// 
        /// </summary>
        CannotSwitchAccountId,

        /// <summary>
        /// 
        /// </summary>
        RequestIncomplete,

        /// <summary>
        /// 
        /// </summary>
        AccountNotNew,

        /// <summary>
        /// 
        /// </summary>
        PasswordLengthInvalid,

        /// <summary>
        /// 
        /// </summary>
        LocalNexusConflict,

        /// <summary>
        /// 
        /// </summary>
        InvalidEcmsOverrideCode,

        /// <summary>
        /// Batch errors
        /// </summary>
        BatchSalesAuditMustBeZippedError,

        /// <summary>
        /// 
        /// </summary>
        BatchZipMustContainOneFileError,

        /// <summary>
        /// 
        /// </summary>
        BatchInvalidFileTypeError,

        /// <summary>
        /// Point Of Sale API exceptions
        /// </summary>
        PointOfSaleFileSize,

        /// <summary>
        /// 
        /// </summary>
        PointOfSaleSetup,

        /// <summary>
        /// Errors in Soap V1 Passthrough / GetTax calls
        /// </summary>
        GetTaxError,

        /// <summary>
        /// 
        /// </summary>
        AddressConflictException,

        /// <summary>
        /// 
        /// </summary>
        DocumentCodeConflict,

        /// <summary>
        /// 
        /// </summary>
        MissingAddress,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameter,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameterValue,

        /// <summary>
        /// 
        /// </summary>
        CompanyCodeConflict,

        /// <summary>
        /// 
        /// </summary>
        DocumentFetchLimit,

        /// <summary>
        /// 
        /// </summary>
        AddressIncomplete,

        /// <summary>
        /// 
        /// </summary>
        AddressLocationNotFound,

        /// <summary>
        /// 
        /// </summary>
        MissingLine,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTextCase,

        /// <summary>
        /// 
        /// </summary>
        DocumentNotCommitted,

        /// <summary>
        /// 
        /// </summary>
        MultiDocumentTypesError,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypesToFetch,

        /// <summary>
        /// Represents a malformed document fetch command
        /// </summary>
        BadDocumentFetch,

        /// <summary>
        /// 
        /// </summary>
        CannotChangeFilingStatus,

        /// <summary>
        /// Represents a SQL server timeout error / deadlock error
        /// </summary>
        ServerUnreachable,

        /// <summary>
        /// Partner API error codes
        /// </summary>
        SubscriptionRequired,

        /// <summary>
        /// 
        /// </summary>
        AccountExists,

        /// <summary>
        /// 
        /// </summary>
        InvitationOnly,

        /// <summary>
        /// 
        /// </summary>
        ZTBListConnectorFail,

        /// <summary>
        /// 
        /// </summary>
        ZTBCreateSubscriptionsFail,

        /// <summary>
        /// 
        /// </summary>
        FreeTrialNotAvailable,

        /// <summary>
        /// 
        /// </summary>
        AccountExistsDifferentEmail,

        /// <summary>
        /// 
        /// </summary>
        AvalaraIdentityApiError,

        /// <summary>
        /// Refund API error codes
        /// </summary>
        InvalidDocumentStatusForRefund,

        /// <summary>
        /// 
        /// </summary>
        RefundTypeAndPercentageMismatch,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypeForRefund,

        /// <summary>
        /// 
        /// </summary>
        RefundTypeAndLineMismatch,

        /// <summary>
        /// 
        /// </summary>
        NullRefundPercentageAndLines,

        /// <summary>
        /// 
        /// </summary>
        InvalidRefundType,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageForTaxOnly,

        /// <summary>
        /// 
        /// </summary>
        LineNoOutOfRange,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageOutOfRange,

        /// <summary>
        /// Free API error codes
        /// </summary>
        TaxRateNotAvailableForFreeInThisCountry,

        /// <summary>
        /// Filing Calendar Error Codes
        /// </summary>
        FilingCalendarCannotBeDeleted,

        /// <summary>
        /// 
        /// </summary>
        InvalidEffectiveDate,

        /// <summary>
        /// 
        /// </summary>
        NonOutletForm,

        /// <summary>
        /// 
        /// </summary>
        OverlappingFilingCalendar,

        /// <summary>
        /// Location error codes
        /// </summary>
        QuestionNotNeededForThisAddress,

        /// <summary>
        /// 
        /// </summary>
        QuestionNotValidForThisAddress,

        /// <summary>
        /// Create or update transaction error codes
        /// </summary>
        CannotModifyLockedTransaction,

        /// <summary>
        /// 
        /// </summary>
        LineAlreadyExists,

        /// <summary>
        /// 
        /// </summary>
        LineDoesNotExist,

        /// <summary>
        /// 
        /// </summary>
        LinesNotSpecified,

        /// <summary>
        /// 
        /// </summary>
        InvalidBusinessType,

        /// <summary>
        /// 
        /// </summary>
        CannotModifyExemptCert,

        /// <summary>
        /// Multi company error codes
        /// </summary>
        TransactionNotCancelled,

        /// <summary>
        /// 
        /// </summary>
        TooManyTransactionLines,

        /// <summary>
        /// 
        /// </summary>
        OnlyTaxDateOverrideIsAllowed,

        /// <summary>
        /// Communications Tax error codes
        /// </summary>
        CommsConfigClientIdMissing,

        /// <summary>
        /// 
        /// </summary>
        CommsConfigClientIdBadValue,

    }

    /// <summary>
    /// ErrorTargetCode
    /// </summary>
    public enum ErrorTargetCode
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown,

        /// <summary>
        /// 
        /// </summary>
        HttpRequest,

        /// <summary>
        /// 
        /// </summary>
        HttpRequestHeaders,

        /// <summary>
        /// 
        /// </summary>
        IncorrectData,

        /// <summary>
        /// 
        /// </summary>
        AvaTaxApiServer,

        /// <summary>
        /// 
        /// </summary>
        AvalaraIdentityServer,

        /// <summary>
        /// 
        /// </summary>
        CustomerAccountSetup,

    }


    /// <summary>
    /// Message object
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Name of the error or message.
        /// </summary>
        public ErrorCodeId? code { get; set; }

        /// <summary>
        /// Unique ID number referring to this error or message.
        /// </summary>
        public Int32? number { get; set; }

        /// <summary>
        /// Concise summary of the message, suitable for display in the caption of an alert box.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// A more detailed description of the problem referenced by this error message, suitable for display in the contents area of an alert box.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Indicates the SOAP Fault code, if this was related to an error that corresponded to AvaTax SOAP v1 behavior.
        /// </summary>
        public String faultCode { get; set; }

        /// <summary>
        /// URL to help for this message
        /// </summary>
        public String helpLink { get; set; }

        /// <summary>
        /// Item the message refers to, if applicable. This is used to indicate a missing or incorrect value.
        /// </summary>
        public String refersTo { get; set; }

        /// <summary>
        /// Severity of the message
        /// </summary>
        public SeverityLevel? severity { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }

    /// <summary>
    /// Severity of message
    /// </summary>
    public enum SeverityLevel
    {
        /// <summary>
        /// Operation succeeded
        /// </summary>
        Success,

        /// <summary>
        /// Warnings occured, operation succeeded
        /// </summary>
        Warning,

        /// <summary>
        /// Errors occured, operation failed
        /// </summary>
        Error,

        /// <summary>
        /// Unexpected exceptions occurred, operation failed
        /// </summary>
        Exception,

    }
}
