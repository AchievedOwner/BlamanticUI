using System;
using System.Collections.Generic;
using System.Reflection;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a 'i' HTML tag to display flag.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    [HtmlTag("i")]
    public class Flag : BlamanticComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flag"/> class.
        /// </summary>
        public Flag()
        {

        }

        /// <summary>
        /// Gets or sets the type of the flag.
        /// </summary>
        [Parameter][CssClass]public Type FlagType { get; set; }
        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("flag");
        }

        /// <summary>
        /// Flag types.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// 安道尔共和国。
            /// </summary>
            [CssClass("ad")]
            Andorra,
            /// <summary>
            /// 阿拉伯联合酋长国。
            /// </summary>
            [CssClass("ae")]
            UnitedArabEmirates,
            /// <summary>
            /// 阿富汗。
            /// </summary>
            [CssClass("af")]
            Afghanistan,
            /// <summary>
            /// 安提瓜岛。
            /// </summary>
            [CssClass("ag")]
            Antigua,
            /// <summary>
            /// 安圭拉岛。
            /// </summary>
            [CssClass("ai")]
            Anguilla,
            /// <summary>
            /// 阿尔巴尼亚。
            /// </summary>
            [CssClass("al")]
            Albania,
            /// <summary>
            /// 亚美尼亚。
            /// </summary>
            [CssClass("am")]
            Armenia,
            /// <summary>
            /// 荷属安的列斯群岛。
            /// </summary>
            [CssClass("an")]
            NetherlandsAntilles,
            /// <summary>
            /// 安哥拉。
            /// </summary>
            [CssClass("ao")]
            Angola,
            /// <summary>
            /// 阿根廷。
            /// </summary>
            [CssClass("ar")]
            Argentina,
            /// <summary>
            /// 美属萨摩亚。
            /// </summary>
            [CssClass("as")]
            AmericanSamoa,
            /// <summary>
            /// 奥地利。
            /// </summary>
            [CssClass("at")]
            Austria,
            /// <summary>
            /// 澳大利亚。
            /// </summary>
            [CssClass("au")]
            Australia,
            /// <summary>
            /// 阿鲁巴岛。
            /// </summary>
            [CssClass("aw")]
            Aruba,
            /// <summary>
            /// 阿兰群岛。
            /// </summary>
            [CssClass("ax")]
            AlandIslands,
            /// <summary>
            /// 阿塞拜疆。
            /// </summary>
            [CssClass("az")]
            Azerbaijan,
            /// <summary>
            /// 波士尼亚。
            /// </summary>
            [CssClass("ba")]
            Bosnia,
            /// <summary>
            /// 巴巴多斯。
            /// </summary>
            [CssClass("bb")]
            Barbados,
            /// <summary>
            /// 孟加拉国。
            /// </summary>
            [CssClass("bd")]
            Bangladesh,
            /// <summary>
            /// 比利时。
            /// </summary>
            [CssClass("be")]
            Belgium,
            /// <summary>
            /// 布基纳法索。
            /// </summary>
            [CssClass("bf")]
            BurkinaFaso,
            /// <summary>
            /// 保加利亚。
            /// </summary>
            [CssClass("bg")]
            Bulgaria,
            /// <summary>
            /// 巴林岛。
            /// </summary>
            [CssClass("bh")]
            Bahrain,
            /// <summary>
            /// 布隆迪。
            /// </summary>
            [CssClass("bi")]
            Burundi,
            /// <summary>
            /// 贝宁。
            /// </summary>
            [CssClass("bj")]
            Benin,
            /// <summary>
            /// 百慕大群岛。
            /// </summary>
            [CssClass("bm")]
            Bermuda,
            /// <summary>
            /// 文莱。
            /// </summary>
            [CssClass("bn")]
            Brunei,
            /// <summary>
            /// 玻利维亚。
            /// </summary>
            [CssClass("bo")]
            Bolivia,
            /// <summary>
            /// 巴西。
            /// </summary>
            [CssClass("br")]
            Brazil,
            /// <summary>
            /// 巴哈马群岛。
            /// </summary>
            [CssClass("bs")]
            Bahamas,
            /// <summary>
            /// 不丹。
            /// </summary>
            [CssClass("bt")]
            Bhutan,
            /// <summary>
            /// 布维岛。
            /// </summary>
            [CssClass("bv")]
            BouvetIsland,
            /// <summary>
            /// 博茨瓦纳。
            /// </summary>
            [CssClass("bw")]
            Botswana,
            /// <summary>
            /// 白俄罗斯。
            /// </summary>
            [CssClass("by")]
            Belarus,
            /// <summary>
            /// 伯利兹城。
            /// </summary>
            [CssClass("bz")]
            Belize,
            /// <summary>
            /// 加拿大。
            /// </summary>
            [CssClass("ca")]
            Canada,
            /// <summary>
            /// 可可群岛。
            /// </summary>
            [CssClass("cc")]
            CocosIslands,
            /// <summary>
            /// 刚果。
            /// </summary>
            [CssClass("cd")]
            Congo,
            /// <summary>
            /// 中非共和国。
            /// </summary>
            [CssClass("cf")]
            CentralAfricanRepublic,
            /// <summary>
            /// 刚果布鲁柴维尔。
            /// </summary>
            [CssClass("cg")]
            CongoBrazzaville,
            /// <summary>
            /// 瑞士。
            /// </summary>
            [CssClass("ch")]
            Switzerland,
            /// <summary>
            /// 科特迪瓦。
            /// </summary>
            [CssClass("ci")]
            CoteDivoire,
            /// <summary>
            /// 库克群岛。
            /// </summary>
            [CssClass("ck")]
            CookIslands,
            /// <summary>
            /// 智利。
            /// </summary>
            [CssClass("cl")]
            Chile,
            /// <summary>
            /// 喀麦隆。
            /// </summary>
            [CssClass("cm")]
            Cameroon,
            /// <summary>
            /// 中国。
            /// </summary>
            [CssClass("cn")]
            China,
            /// <summary>
            /// 哥伦比亚。
            /// </summary>
            [CssClass("co")]
            Colombia,
            /// <summary>
            /// 哥斯达尼加。
            /// </summary>
            [CssClass("cr")]
            CostaRica,
            /// <summary>
            /// 塞尔维亚。
            /// </summary>
            [CssClass("cs")]
            Serbia,
            /// <summary>
            /// 古巴。
            /// </summary>
            [CssClass("cu")]
            Cuba,
            /// <summary>
            /// 佛得角。
            /// </summary>
            [CssClass("cv")]
            CapeVerde,
            /// <summary>
            /// 圣诞群岛。
            /// </summary>
            [CssClass("cx")]
            ChristmasIsland,
            /// <summary>
            /// 塞浦路斯。
            /// </summary>
            [CssClass("cy")]
            Cyprus,
            /// <summary>
            /// 捷克共和国。
            /// </summary>
            [CssClass("cz")]
            CzechRepublic,
            /// <summary>
            /// 德国。
            /// </summary>
            [CssClass("de")]
            Germany,
            /// <summary>
            /// 吉布提。
            /// </summary>
            [CssClass("dj")]
            Djibouti,
            /// <summary>
            /// 丹麦。
            /// </summary>
            [CssClass("dk")]
            Denmark,
            /// <summary>
            /// 多美尼加岛。
            /// </summary>
            [CssClass("dm")]
            Dominica,
            /// <summary>
            /// 多美尼加共和国。
            /// </summary>
            [CssClass("do")]
            DominicanRepublic,
            /// <summary>
            /// 阿尔及利亚。
            /// </summary>
            [CssClass("dz")]
            Algeria,
            /// <summary>
            /// 厄瓜多尔。
            /// </summary>
            [CssClass("ec")]
            Ecuador,
            /// <summary>
            /// 爱沙尼亚。
            /// </summary>
            [CssClass("ee")]
            Estonia,
            /// <summary>
            /// 埃及。
            /// </summary>
            [CssClass("eg")]
            Egypt,
            /// <summary>
            /// 西撒哈拉。
            /// </summary>
            [CssClass("eh")]
            WesternSahara,
            /// <summary>
            /// 厄立特里亚国。
            /// </summary>
            [CssClass("er")]
            Eritrea,
            /// <summary>
            /// 西班牙。
            /// </summary>
            [CssClass("es")]
            Spain,
            /// <summary>
            /// 埃塞俄比亚。
            /// </summary>
            [CssClass("et")]
            Ethiopia,
            /// <summary>
            /// 欧盟。
            /// </summary>
            [CssClass("eu")]
            EuropeanUnion,
            /// <summary>
            /// 芬兰。
            /// </summary>
            [CssClass("fi")]
            Finland,
            /// <summary>
            /// 斐济。
            /// </summary>
            [CssClass("fj")]
            Fiji,
            /// <summary>
            /// 福克兰群岛。
            /// </summary>
            [CssClass("fk")]
            FalklandIslands,
            /// <summary>
            /// 密克罗尼西亚。
            /// </summary>
            [CssClass("fm")]
            Micronesia,
            /// <summary>
            /// 法罗群岛。
            /// </summary>
            [CssClass("fo")]
            FaroeIslands,
            /// <summary>
            /// 法国。
            /// </summary>
            [CssClass("fr")]
            France,
            /// <summary>
            /// 加蓬。
            /// </summary>
            [CssClass("ga")]
            Gabon,
            /// <summary>
            /// 大不列颠帝国。
            /// </summary>
            [CssClass("gb uk")]
            UnitedKingdom,
            /// <summary>
            /// 英格兰。
            /// </summary>
            [CssClass("gb eng")]
            England,
            /// <summary>
            /// 苏格兰。
            /// </summary>
            [CssClass("gb sct")]
            Scotland,
            /// <summary>
            /// 威尔士。
            /// </summary>
            [CssClass("gb wls")]
            Wales,
            /// <summary>
            /// 格林纳达。
            /// </summary>
            [CssClass("gd")]
            Grenada,
            /// <summary>
            /// 格鲁吉亚。
            /// </summary>
            [CssClass("ge")]
            Georgia,
            /// <summary>
            /// 法属圭亚那。
            /// </summary>
            [CssClass("gf")]
            FrenchGuiana,
            /// <summary>
            /// 加纳。
            /// </summary>
            [CssClass("gh")]
            Ghana,
            /// <summary>
            /// 直布罗陀。
            /// </summary>
            [CssClass("gi")]
            Gibraltar,
            /// <summary>
            /// 格陵兰。
            /// </summary>
            [CssClass("gl")]
            Greenland,
            /// <summary>
            /// 冈比亚。
            /// </summary>
            [CssClass("gm")]
            Gambia,
            /// <summary>
            /// 几内亚。
            /// </summary>
            [CssClass("gn")]
            Guinea,
            /// <summary>
            /// 瓜德罗管岛。
            /// </summary>
            [CssClass("gp")]
            Guadeloupe,
            /// <summary>
            /// 赤道几内亚。
            /// </summary>
            [CssClass("gq")]
            EquatorialGuinea,
            /// <summary>
            /// 希腊。
            /// </summary>
            [CssClass("gr")]
            Greece,
            /// <summary>
            /// 三明治群岛。
            /// </summary>
            [CssClass("gs")]
            SandwichIslands,
            /// <summary>
            /// 危地马拉。
            /// </summary>
            [CssClass("gt")]
            Guatemala,
            /// <summary>
            /// 关岛。
            /// </summary>
            [CssClass("gu")]
            Guam,
            /// <summary>
            /// 几内亚比绍。
            /// </summary>
            [CssClass("gw")]
            Guineabissau,
            /// <summary>
            /// 圭亚那。
            /// </summary>
            [CssClass("gy")]
            Guyana,
            /// <summary>
            /// 香港。
            /// </summary>
            [CssClass("hk")]
            HongKong,
            /// <summary>
            ///  核德群岛。
            /// </summary>
            [CssClass("hm")]
            HeardIsland,
            /// <summary>
            /// 洪都拉斯。
            /// </summary>
            [CssClass("hn")]
            Honduras,
            /// <summary>
            /// 克罗地亚。
            /// </summary>
            [CssClass("hr")]
            Croatia,
            /// <summary>
            /// 海地共和国。
            /// </summary>
            [CssClass("ht")]
            Haiti,
            /// <summary>
            /// 匈牙利。
            /// </summary>
            [CssClass("hu")]
            Hungary,
            /// <summary>
            /// 印度尼西亚。
            /// </summary>
            [CssClass("id")]
            Indonesia,
            /// <summary>
            /// 爱尔兰。
            /// </summary>
            [CssClass("ie")]
            Ireland,
            /// <summary>
            /// 以色列。
            /// </summary>
            [CssClass("il")]
            Israel,
            /// <summary>
            /// 印度。
            /// </summary>
            [CssClass("in")]
            India,
            /// <summary>
            /// 印度洋地区。
            /// </summary>
            [CssClass("io")]
            IndianOceanTerritory,
            /// <summary>
            /// 伊拉克。
            /// </summary>
            [CssClass("iq")]
            Iraq,
            /// <summary>
            /// 伊朗。
            /// </summary>
            [CssClass("ir")]
            Iran,
            /// <summary>
            /// 冰岛。
            /// </summary>
            [CssClass("is")]
            Iceland,
            /// <summary>
            /// 意大利。
            /// </summary>
            [CssClass("it")]
            Italy,
            /// <summary>
            /// 牙买加。
            /// </summary>
            [CssClass("jm")]
            Jamaica,
            /// <summary>
            /// 约旦。
            /// </summary>
            [CssClass("jo")]
            Jordan,
            /// <summary>
            /// 日本。
            /// </summary>
            [CssClass("jp")]
            Japan,
            /// <summary>
            /// 肯尼亚。
            /// </summary>
            [CssClass("ke")]
            Kenya,
            /// <summary>
            /// 吉尔吉斯斯坦。
            /// </summary>
            [CssClass("kg")]
            Kyrgyzstan,
            /// <summary>
            /// 柬埔寨。
            /// </summary>
            [CssClass("kh")]
            Cambodia,
            /// <summary>
            /// 基里巴斯。
            /// </summary>
            [CssClass("ki")]
            Kiribati,
            /// <summary>
            /// 科摩罗。
            /// </summary>
            [CssClass("km")]
            Comoros,
            /// <summary>
            /// 圣基茨和尼维斯。
            /// </summary>
            [CssClass("kn")]
            SaintKittsAndNevis,
            /// <summary>
            /// 朝鲜。
            /// </summary>
            [CssClass("kp")]
            NorthKorea,
            /// <summary>
            /// 韩国。
            /// </summary>
            [CssClass("kr")]
            SouthKorea,
            /// <summary>
            /// 科威特。
            /// </summary>
            [CssClass("kw")]
            Kuwait,
            /// <summary>
            /// 开曼群岛。
            /// </summary>
            [CssClass("ky")]
            CaymanIslands,
            /// <summary>
            /// 哈萨克斯坦。
            /// </summary>
            [CssClass("kz")]
            Kazakhstan,
            /// <summary>
            /// 老挝。
            /// </summary>
            [CssClass("la")]
            Laos,
            /// <summary>
            /// 黎巴嫩。
            /// </summary>
            [CssClass("lb")]
            Lebanon,
            /// <summary>
            /// 圣卢西亚岛。
            /// </summary>
            [CssClass("lc")]
            SaintLucia,
            /// <summary>
            /// 列支敦斯登。
            /// </summary>
            [CssClass("li")]
            Liechtenstein,
            /// <summary>
            /// 斯里兰卡。
            /// </summary>
            [CssClass("lk")]
            SriLanka,
            /// <summary>
            /// 利比里亚。
            /// </summary>
            [CssClass("lr")]
            Liberia,
            /// <summary>
            /// 莱索托。
            /// </summary>
            [CssClass("ls")]
            Lesotho,
            /// <summary>
            /// 立陶宛。
            /// </summary>
            [CssClass("lt")]
            Lithuania,
            /// <summary>
            /// 卢森堡公国。
            /// </summary>
            [CssClass("lu")]
            Luxembourg,
            /// <summary>
            /// 拉脱维亚。
            /// </summary>
            [CssClass("lv")]
            Latvia,
            /// <summary>
            /// 利比亚。
            /// </summary>
            [CssClass("ly")]
            Libya,
            /// <summary>
            /// 摩洛哥。
            /// </summary>
            [CssClass("ma")]
            Morocco,
            /// <summary>
            /// 摩纳哥。
            /// </summary>
            [CssClass("mc")]
            Monaco,
            /// <summary>
            /// 摩尔多瓦。
            /// </summary>
            [CssClass("md")]
            Moldova,
            /// <summary>
            /// 黑山共和国。
            /// </summary>
            [CssClass("me")]
            Montenegro,
            /// <summary>
            /// 马达加斯加群岛。
            /// </summary>
            [CssClass("mg")]
            Madagascar,
            /// <summary>
            /// 马绍尔群岛。
            /// </summary>
            [CssClass("mh")]
            MarshallIslands,
            /// <summary>
            /// 马其顿。
            /// </summary>
            [CssClass("mk")]
            Macedonia,
            /// <summary>
            /// 马里共和国。
            /// </summary>
            [CssClass("ml")]
            Mali,
            /// <summary>
            /// 缅甸。
            /// </summary>
            [CssClass("mm")]
            Burma,
            /// <summary>
            /// 蒙古。
            /// </summary>
            [CssClass("mn")]
            Mongolia,
            /// <summary>
            /// 澳门。
            /// </summary>
            [CssClass("mo")]
            Macau,
            /// <summary>
            /// 北马里亚纳群岛。
            /// </summary>
            [CssClass("mp")]
            NorthernMarianaIslands,
            /// <summary>
            /// 马提尼克。
            /// </summary>
            [CssClass("mq")]
            Martinique,
            /// <summary>
            ///  毛里塔尼亚。
            /// </summary>
            [CssClass("mr")]
            Mauritania,
            /// <summary>
            /// 蒙特斯拉特岛。
            /// </summary>
            [CssClass("ms")]
            Montserrat,
            /// <summary>
            /// 马耳他。
            /// </summary>
            [CssClass("mt")]
            Malta,
            /// <summary>
            /// 毛里求斯。
            /// </summary>
            [CssClass("mu")]
            Mauritius,
            /// <summary>
            /// 马尔代夫。
            /// </summary>
            [CssClass("mv")]
            Maldives,
            /// <summary>
            /// 马拉维。
            /// </summary>
            [CssClass("mw")]
            Malawi,
            /// <summary>
            /// 墨西哥。
            /// </summary>
            [CssClass("mx")]
            Mexico,
            /// <summary>
            /// 马来西亚。
            /// </summary>
            [CssClass("my")]
            Malaysia,
            /// <summary>
            /// 莫桑比克。
            /// </summary>
            [CssClass("mz")]
            Mozambique,
            /// <summary>
            /// 纳米比亚。
            /// </summary>
            [CssClass("na")]
            Namibia,
            /// <summary>
            /// 新喀里多尼亚。
            /// </summary>
            [CssClass("nc")]
            NewCaledonia,
            /// <summary>
            /// 尼日尔。
            /// </summary>
            [CssClass("ne")]
            Niger,
            /// <summary>
            /// 诺福克岛。
            /// </summary>
            [CssClass("nf")]
            NorfolkIsland,
            /// <summary>
            /// 尼日利亚。
            /// </summary>
            [CssClass("ng")]
            Nigeria,
            /// <summary>
            /// 尼加拉瓜。
            /// </summary>
            [CssClass("ni")]
            Nicaragua,
            /// <summary>
            /// 荷兰。
            /// </summary>
            [CssClass("nl")]
            Netherlands,
            /// <summary>
            /// 挪威。
            /// </summary>
            [CssClass("no")]
            Norway,
            /// <summary>
            /// 尼泊尔。
            /// </summary>
            [CssClass("np")]
            Nepal,
            /// <summary>
            /// 瑙鲁。
            /// </summary>
            [CssClass("nr")]
            Nauru,
            /// <summary>
            /// 纽埃岛。
            /// </summary>
            [CssClass("nu")]
            Niue,
            /// <summary>
            /// 新西兰。
            /// </summary>
            [CssClass("nz")]
            NewZealand,
            /// <summary>
            /// 阿曼。
            /// </summary>
            [CssClass("om")]
            Oman,
            /// <summary>
            /// 巴拿马。
            /// </summary>
            [CssClass("pa")]
            Panama,
            /// <summary>
            /// 秘鲁。
            /// </summary>
            [CssClass("pe")]
            Peru,
            /// <summary>
            /// 法属波利尼西亚。
            /// </summary>
            [CssClass("pf")]
            FrenchPolynesia,
            /// <summary>
            /// 新几内亚。
            /// </summary>
            [CssClass("pg")]
            NewGuinea,
            /// <summary>
            /// 菲律宾。
            /// </summary>
            [CssClass("ph")]
            Philippines,
            /// <summary>
            /// 巴基斯坦。
            /// </summary>
            [CssClass("pk")]
            Pakistan,
            /// <summary>
            /// 波兰。
            /// </summary>
            [CssClass("pl")]
            Poland,
            /// <summary>
            /// 圣皮埃尔。
            /// </summary>
            [CssClass("pm")]
            SaintPierre,
            /// <summary>
            /// 皮特凯恩群岛。
            /// </summary>
            [CssClass("pn")]
            PitcairnIslands,
            /// <summary>
            /// 波多黎各。
            /// </summary>
            [CssClass("pr")]
            PuertoRico,
            /// <summary>
            /// 巴勒斯坦。
            /// </summary>
            [CssClass("ps")]
            Palestine,
            /// <summary>
            /// 葡萄牙。
            /// </summary>
            [CssClass("pt")]
            Portugal,
            /// <summary>
            /// 帕劳群岛。
            /// </summary>
            [CssClass("pw")]
            Palau,
            /// <summary>
            /// 巴拉圭。
            /// </summary>
            [CssClass("py")]
            Paraguay,
            /// <summary>
            /// 卡塔尔。
            /// </summary>
            [CssClass("qa")]
            Qatar,
            /// <summary>
            /// 留尼旺。
            /// </summary>
            [CssClass("re")]
            Reunion,
            /// <summary>
            /// 罗马尼亚。
            /// </summary>
            [CssClass("ro")]
            Romania,
            /// <summary>
            /// 俄罗斯。
            /// </summary>
            [CssClass("ru")]
            Russia,
            /// <summary>
            /// 卢旺达。
            /// </summary>
            [CssClass("rw")]
            Rwanda,
            /// <summary>
            /// 沙特阿拉伯。
            /// </summary>
            [CssClass("sa")]
            SaudiArabia,
            /// <summary>
            /// 所罗门群岛。
            /// </summary>
            [CssClass("sb")]
            SolomonIslands,
            /// <summary>
            /// 塞舌尔。
            /// </summary>
            [CssClass("sc")]
            Seychelles,
            /// <summary>
            /// 苏丹。
            /// </summary>
            [CssClass("sd")]
            Sudan,
            /// <summary>
            /// 瑞典。
            /// </summary>
            [CssClass("se")]
            Sweden,
            /// <summary>
            /// 新加坡。
            /// </summary>
            [CssClass("sg")]
            Singapore,
            /// <summary>
            /// 圣赫勒拿。
            /// </summary>
            [CssClass("sh")]
            SaintHelena,
            /// <summary>
            /// 斯洛文尼亚。
            /// </summary>
            [CssClass("si")]
            Slovenia,
            /// <summary>
            /// 塞拉利昂。
            /// </summary>
            [CssClass("sl")]
            SierraLeone,
            /// <summary>
            /// 圣马力诺。
            /// </summary>
            [CssClass("sm")]
            SanMarino,
            /// <summary>
            /// 塞内加尔。
            /// </summary>
            [CssClass("sn")]
            Senegal,
            /// <summary>
            /// 索马里。
            /// </summary>
            [CssClass("so")]
            Somalia,
            /// <summary>
            /// 苏里南共和国。
            /// </summary>
            [CssClass("sr")]
            Suriname,
            /// <summary>
            /// 圣多美。
            /// </summary>
            [CssClass("st")]
            SaoTome,
            /// <summary>
            /// 萨尔瓦多。
            /// </summary>
            [CssClass("sv")]
            ElSalvador,
            /// <summary>
            /// 叙利亚。
            /// </summary>
            [CssClass("sy")]
            Syria,
            /// <summary>
            /// 斯威士兰。
            /// </summary>
            [CssClass("sz")]
            Swaziland,
            /// <summary>
            /// 凯克斯群岛。
            /// </summary>
            [CssClass("tc")]
            CaicosIslands,
            /// <summary>
            /// 乍得。
            /// </summary>
            [CssClass("td")]
            Chad,
            /// <summary>
            /// 求翻译。
            /// </summary>
            [CssClass("tf")]
            FrenchTerritories,
            /// <summary>
            /// 多哥。
            /// </summary>
            [CssClass("tg")]
            Togo,
            /// <summary>
            /// 泰国。
            /// </summary>
            [CssClass("th")]
            Thailand,
            /// <summary>
            /// 塔吉克斯坦。
            /// </summary>
            [CssClass("tj")]
            Tajikistan,
            /// <summary>
            /// 托克劳群岛。
            /// </summary>
            [CssClass("tk")]
            Tokelau,
            /// <summary>
            /// 东帝汶。
            /// </summary>
            [CssClass("tl")]
            Timorleste,
            /// <summary>
            /// 土库曼斯坦。
            /// </summary>
            [CssClass("tm")]
            Turkmenistan,
            /// <summary>
            /// 突尼斯。
            /// </summary>
            [CssClass("tn")]
            Tunisia,
            /// <summary>
            /// 汤加。
            /// </summary>
            [CssClass("to")]
            Tonga,
            /// <summary>
            /// 土耳其。
            /// </summary>
            [CssClass("tr")]
            Turkey,
            /// <summary>
            /// 特立尼达拉岛。
            /// </summary>
            [CssClass("tt")]
            Trinidad,
            /// <summary>
            /// 图瓦卢。
            /// </summary>
            [CssClass("tv")]
            Tuvalu,
            /// <summary>
            /// 台湾。
            /// </summary>
            [CssClass("tw")]
            Taiwan,
            /// <summary>
            /// 坦桑尼亚。
            /// </summary>
            [CssClass("tz")]
            Tanzania,
            /// <summary>
            /// 乌克兰。
            /// </summary>
            [CssClass("ua")]
            Ukraine,
            /// <summary>
            /// 乌干达。
            /// </summary>
            [CssClass("ug")]
            Uganda,
            /// <summary>
            /// 美国本土外小岛屿。
            /// </summary>
            [CssClass("um")]
            UsMinorIslands,
            /// <summary>
            /// 美国。
            /// </summary>
            [CssClass("us")]
            UnitedStates,
            /// <summary>
            /// 乌拉圭。
            /// </summary>
            [CssClass("uy")]
            Uruguay,
            /// <summary>
            /// 乌兹别克斯坦。
            /// </summary>
            [CssClass("uz")]
            Uzbekistan,
            /// <summary>
            /// 梵蒂冈。
            /// </summary>
            [CssClass("va")]
            VaticanCity,
            /// <summary>
            /// 圣文森特岛。
            /// </summary>
            [CssClass("vc")]
            SaintVincent,
            /// <summary>
            /// 委内瑞拉。
            /// </summary>
            [CssClass("ve")]
            Venezuela,
            /// <summary>
            /// 英属维尔京群岛。
            /// </summary>
            [CssClass("vg")]
            BritishVirginIslands,
            /// <summary>
            /// 美属维尔京群岛。
            /// </summary>
            [CssClass("vi")]
            UsVirginIslands,
            /// <summary>
            /// 越南。
            /// </summary>
            [CssClass("vn")]
            Vietnam,
            /// <summary>
            /// 瓦努阿图。
            /// </summary>
            [CssClass("vu")]
            Vanuatu,
            /// <summary>
            /// 瓦利斯群岛和富图纳群岛。
            /// </summary>
            [CssClass("wf")]
            WallisAndFutuna,
            /// <summary>
            /// 萨摩亚。
            /// </summary>
            [CssClass("ws")]
            Samoa,
            /// <summary>
            /// 也门。
            /// </summary>
            [CssClass("ye")]
            Yemen,
            /// <summary>
            /// 马约特岛。
            /// </summary>
            [CssClass("yt")]
            Mayotte,
            /// <summary>
            /// 南非、
            /// </summary>
            [CssClass("za")]
            SouthAfrica,
            /// <summary>
            /// 赞比亚。
            /// </summary>
            [CssClass("zm")]
            Zambia,
            /// <summary>
            /// 津巴布韦。
            /// </summary>
            [CssClass("zw")]
            Zimbabwe,
        }
    }
}
