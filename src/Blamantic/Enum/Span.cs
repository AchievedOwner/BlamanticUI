using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// 表示列的跨度，总共分为 16 个单位。
    /// </summary>
    /// <seealso cref="YoiBlazor.CssClass" />
    public class ColSpan : CssClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColSpan"/> class.
        /// </summary>
        /// <param name="cssClass">类样式。支持 <see cref="T:System.String" />、<see cref="T:System.Enum" /> 或 <see cref="T:YoiBlazor.CssClass" /> 类型。</param>
        private ColSpan(object cssClass) : base(cssClass)
        {
        }

        /// <summary>
        /// 表示跨列1个单位。
        /// </summary>
        public readonly static ColSpan One1 = new ColSpan("one");
        /// <summary>
        /// 表示跨列2个单位。
        /// </summary>
        public readonly static ColSpan Two2 = new ColSpan("two");
        /// <summary>
        /// 表示跨列3个单位。
        /// </summary>
        public readonly static ColSpan Three3 = new ColSpan("three");
        /// <summary>
        /// 表示跨列4个单位。
        /// </summary>
        public readonly static ColSpan Four4 = new ColSpan("four");
        /// <summary>
        /// 表示跨列5个单位。
        /// </summary>
        public readonly static ColSpan Five5 = new ColSpan("five");
        /// <summary>
        /// 表示跨列6个单位。
        /// </summary>
        public readonly static ColSpan Six6 = new ColSpan("six");
        /// <summary>
        /// 表示跨列7个单位。
        /// </summary>
        public readonly static ColSpan Seven7 = new ColSpan("seven");
        /// <summary>
        /// 表示跨列8个单位。
        /// </summary>
        public readonly static ColSpan Eight8 = new ColSpan("eight");
        /// <summary>
        /// 表示跨列9个单位。
        /// </summary>
        public readonly static ColSpan Nine9 = new ColSpan("nine");
        /// <summary>
        /// 表示跨列10个单位。
        /// </summary>
        public readonly static ColSpan Ten10 = new ColSpan("ten");
        /// <summary>
        /// 表示跨列11个单位。
        /// </summary>
        public readonly static ColSpan Eleven11 = new ColSpan("eleven");
        /// <summary>
        /// 表示跨列12个单位。
        /// </summary>
        public readonly static ColSpan Twelve12 = new ColSpan("twelve");
        /// <summary>
        /// 表示跨列13个单位。
        /// </summary>
        public readonly static ColSpan Thirteen13 = new ColSpan("thirteen");
        /// <summary>
        /// 表示跨列14个单位。
        /// </summary>
        public readonly static ColSpan Fourteen14 = new ColSpan("fourteen");
        /// <summary>
        /// 表示跨列15个单位。
        /// </summary>
        public readonly static ColSpan Fifteen15 = new ColSpan("fifteen");

        /// <summary>
        /// 表示跨列16个单位。
        /// </summary>
        public readonly static ColSpan Sixteen16 = new ColSpan("sixteen");

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="ColSpan"/>.
        /// </summary>
        /// <param name="span">The span.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ColSpan(int span)
         => span switch
         {
             1 => One1,
             2 => Two2,
             3 => Three3,
             4 => Four4,
             5 => Five5,
             6 => Six6,
             7 => Seven7,
             8 => Eight8,
             9 => Nine9,
             10 => Ten10,
             11 => Eleven11,
             12 => Twelve12,
             13 => Thirteen13,
             14 => Fourteen14,
             15 => Fifteen15,
             _ => Sixteen16,
         };
    }
}
