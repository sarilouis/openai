namespace OpenAI.GPT3.ObjectModels
{
    public static class Models
    {
        public enum BaseEngine
        {
            Ada,
            Babbage,
            Curie,
            Davinci,
            Cushman
        }

        public enum Model
        {
            Ada,
            Babbage,
            Curie,
            Davinci,

            TextAdaV1,
            TextBabbageV1,
            TextCurieV1,
            TextDavinciV1,

            TextDavinciV2,

            CurieInstructBeta,
            DavinciInstructBeta,

            CurieSimilarityFast,

            TextSimilarityAdaV1,
            TextSimilarityBabbageV1,
            TextSimilarityCurieV1,
            TextSimilarityDavinciV1,

            TextSearchAdaDocV1,
            TextSearchBabbageDocV1,
            TextSearchCurieDocV1,
            TextSearchDavinciDocV1,

            TextSearchAdaQueryV1,
            TextSearchBabbageQueryV1,
            TextSearchCurieQueryV1,
            TextSearchDavinciQueryV1,

            CodeSearchAdaCodeV1,
            CodeSearchBabbageCodeV1,

            CodeSearchAdaTextV1,
            CodeSearchBabbageTextV1,

            CodeDavinciV1,
            CodeCushmanV1,

            CodeDavinciV2
        }

        private enum Subject
        {
            Text,
            InstructBeta,
            SimilarityFast,
            TextSimilarity,
            TextSearchDocument,
            TextSearchQuery,
            CodeSearchCode,
            CodeSearchText,
            Code
        }

        public static string Ada => "ada";
        public static string Babbage => "babbage";
        public static string Curie => "curie";
        public static string Davinci => "davinci";

        public static string CurieInstructBeta => ModelNameBuilder(BaseEngine.Curie, Subject.InstructBeta);
        public static string DavinciInstructBeta => ModelNameBuilder(BaseEngine.Davinci, Subject.InstructBeta);

        public static string TextDavinciV1 => ModelNameBuilder(BaseEngine.Davinci, Subject.Text, "001");
        public static string TextDavinciV2 => ModelNameBuilder(BaseEngine.Davinci, Subject.Text, "002");
        public static string TextAdaV1 => ModelNameBuilder(BaseEngine.Ada, Subject.Text, "001");
        public static string TextBabbageV1 => ModelNameBuilder(BaseEngine.Babbage, Subject.Text, "001");
        public static string TextCurieV1 => ModelNameBuilder(BaseEngine.Curie, Subject.Text, "001");

        public static string CurieSimilarityFast => ModelNameBuilder(BaseEngine.Curie, Subject.SimilarityFast);

        public static string CodeDavinciV1 => ModelNameBuilder(BaseEngine.Davinci, Subject.Code, "001");
        public static string CodeCushmanV1 => ModelNameBuilder(BaseEngine.Cushman, Subject.Code, "001");
        public static string CodeDavinciV2 => ModelNameBuilder(BaseEngine.Davinci, Subject.Code, "002");

        public static string TextSimilarityAdaV1 => ModelNameBuilder(BaseEngine.Ada, Subject.TextSimilarity, "001");
        public static string TextSimilarityBabbageV1 => ModelNameBuilder(BaseEngine.Babbage, Subject.TextSimilarity, "001");
        public static string TextSimilarityCurieV1 => ModelNameBuilder(BaseEngine.Curie, Subject.TextSimilarity, "001");
        public static string TextSimilarityDavinciV1 => ModelNameBuilder(BaseEngine.Davinci, Subject.TextSimilarity, "001");

        public static string TextSearchAdaDocV1 => ModelNameBuilder(BaseEngine.Ada, Subject.TextSearchDocument, "001");
        public static string TextSearchBabbageDocV1 => ModelNameBuilder(BaseEngine.Babbage, Subject.TextSearchDocument, "001");
        public static string TextSearchCurieDocV1 => ModelNameBuilder(BaseEngine.Curie, Subject.TextSearchDocument, "001");
        public static string TextSearchDavinciDocV1 => ModelNameBuilder(BaseEngine.Davinci, Subject.TextSearchDocument, "001");
        public static string TextSearchAdaQueryV1 => ModelNameBuilder(BaseEngine.Ada, Subject.TextSearchQuery, "001");
        public static string TextSearchBabbageQueryV1 => ModelNameBuilder(BaseEngine.Babbage, Subject.TextSearchQuery, "001");
        public static string TextSearchCurieQueryV1 => ModelNameBuilder(BaseEngine.Curie, Subject.TextSearchQuery, "001");
        public static string TextSearchDavinciQueryV1 => ModelNameBuilder(BaseEngine.Davinci, Subject.TextSearchQuery, "001");

        public static string CodeSearchAdaCodeV1 => ModelNameBuilder(BaseEngine.Ada, Subject.CodeSearchCode, "001");
        public static string CodeSearchBabbageCodeV1 => ModelNameBuilder(BaseEngine.Babbage, Subject.CodeSearchCode, "001");
        public static string CodeSearchAdaTextV1 => ModelNameBuilder(BaseEngine.Ada, Subject.CodeSearchText, "001");
        public static string CodeSearchBabbageTextV1 => ModelNameBuilder(BaseEngine.Babbage, Subject.CodeSearchText, "001");


        /// <summary>
        ///     This method does not guarantee returned model exists.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="version"></param>
        /// <param name="baseEngine"></param>
        /// <returns></returns>
        private static string ModelNameBuilder(this BaseEngine baseEngine, Subject? subject = null, string? version = null)
        {
            var response = subject?.EnumToString(baseEngine) ?? $"{baseEngine.EnumToString()}";

            if (!string.IsNullOrEmpty(version))
            {
                response += $"-{version}";
            }

            return response;
        }

        private static string EnumToString(this BaseEngine baseEngine)
        {
            return baseEngine switch
            {
                BaseEngine.Ada => Ada,
                BaseEngine.Babbage => Babbage,
                BaseEngine.Curie => Curie,
                BaseEngine.Davinci => Davinci,
                BaseEngine.Cushman => "cushman",
                _ => throw new ArgumentOutOfRangeException(nameof(baseEngine), baseEngine, null)
            };
        }

        private static string EnumToString(this Subject subject, BaseEngine baseEngine)
        {
            return string.Format(subject switch
            {
                //{0}-{1}
                Subject.Text => "text-{0}",
                Subject.InstructBeta => "{0}-instruct-beta",
                Subject.SimilarityFast => "{0}-similarity-fast",
                Subject.TextSimilarity => "text-similarity-{0}",
                Subject.TextSearchDocument => "text-search-{0}-doc",
                Subject.TextSearchQuery => "text-search-{0}-query",
                Subject.CodeSearchCode => "code-search-{0}-code",
                Subject.CodeSearchText => "code-search-{0}-text",
                Subject.Code => "code-{0}",
                _ => throw new ArgumentOutOfRangeException(nameof(subject), subject, null)
            }, baseEngine.EnumToString());
        }
    }
}