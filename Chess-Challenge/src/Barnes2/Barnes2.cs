﻿using ChessChallenge.API;
using System;
using System.Linq;

public class Barnes2 : IChessBot
{
    double[,] q_w1 = new double[384, 16];
    double[,] q_w2 = new double[16, 16];
    double[,] q_w3 = new double[16, 1];
    double[,] b1 = {{-0.2105952948331833, 0.3373734652996063, -2.665067672729492, -0.17655938863754272, -0.18837878108024597, -0.31420087814331055, -2.4298295974731445, 0.8483097553253174, -0.16813413798809052, -0.5404060482978821, 1.6258624792099, -0.21038718521595, 0.9587255716323853, -0.14954684674739838, 1.1288930177688599, -0.3819195330142975}};
    double[,] b2 = {{-0.37279853224754333, 2.0980989933013916, 0.4406026005744934, 1.8609669208526611, -0.4291727840900421, 1.9326260089874268, 0.8186648488044739, 1.2451813220977783, 1.0008747577667236, -0.25214970111846924, -0.650875985622406, -2.5601110458374023, -0.7385462522506714, -0.7589142322540283, -0.37014609575271606, 0.5667510032653809}};
    double[,] b3 = {{0.45780158042907715}};
    
    double w1_S = 0.037210047245025635;

    double w2_S = 0.020057767629623413;

    double w3_S = 0.011218558996915817;
    bool searchCancelled => searchTimer.MillisecondsElapsedThisTurn > searchMaxTime;
    int searchMaxTime;
    Timer searchTimer;
    Move bestMoveThisIteration;
    Move bestMove;
    double bestEvalThisIteration;
    double bestEval;
    int mDepth;
    public Barnes2(){
        UInt64[] w1 = {10121665870736688513, 9402534706018615943, 9120219744921222288, 8395981232910731891, 8399052211467484027, 9978148898708884364, 9472333817188087678, 10480022024749873539, 9470922129857742473, 9258120454771345279, 9837126542067075196, 9046195090354966633, 9472055704937721725, 8899254097468490099, 9979258163719406985, 9185249136213195916, 9836538268448746094, 10412168868368646015, 7603327932666776678, 9121050885701858437, 11638001264892015218, 11205648000326466697, 8972138588572649816, 6230298429792220308, 11061534985401691499, 10991165218856466310, 10053302665412707444, 7317641899420774793, 9044489739899142264, 9554518084464245134, 9620106084252015990, 8321375137903114373, 9836823037447793521, 10846489159825259648, 8395968085595163242, 8613268906746476167, 9908615743840616570, 12504095379262239886, 9332725634531756904, 4502890985842503563, 9692717809753357949, 11931014555615589781, 9909190711531372918, 6594528204650411149, 7531270360808260475, 10417239979070879368, 8611585644820719735, 8393997889541141896, 9548593782433018993, 10919107552053460867, 7243046610919196272, 9548891810835362183, 9404503905153613428, 10995108029233134473, 7819511739946007412, 7247554540192427398, 9548918199231218038, 10997078336840956557, 8540089857889302138, 6957634231631245959, 8684196246164765811, 10199659766323117197, 8971871398891842168, 8680534919019068550, 8611849458472417394, 9186629117559668108, 8755974593827601264, 9910583861685220755, 9476271249798494325, 10921360498741049241, 8612145369087245175, 10414988158100926853, 7891297776305143161, 10058081078776328585, 7963355408980734329, 8901494919009170295, 7603060755771915644, 9909454615831737979, 9044207125969468020, 9186063822673706881, 8611566879907346800, 9621504679617462163, 8900102001169233015, 9761682490869905807, 8539527891619051639, 9479363218044056969, 8828034597441272182, 9474855048640361855, 8611851499053349754, 10199091542352294766, 8323640200826744953, 9547192953701562483, 8035399671138781560, 10125067785334255483, 8683913683822999412, 9839648744399601001, 8972139580490610288, 8829152559980773778, 8827759594897700982, 10269178631111209867, 8539808275623474289, 8540639678143625864, 8468021453716290668, 10050455969947615880, 8035113673979229296, 9327078546941965956, 8107454198871324282, 9980383028808676452, 8107449560105651061, 11059842785672393348, 8899809363254017650, 9983200965308219499, 9618142347409459844, 9907771259150304386, 9047300189634328711, 8174168015738275184, 8901507026958975874, 9404770051426254974, 10340690781551886967, 9837412483844109957, 9258407345602198390, 8535584093834081399, 8325339908432563317, 9188883099402797438, 8246777474805365633, 8897271806750849919, 9615610133660793722, 8900389957336986494, 3928722607854676587, 5229654899918072481, 9984633770827283066, 10054704581630064024, 9984283902756491886, 8326716325073677493, 5877339790187732083, 3419486073400550268, 10777262872888116612, 7455552487128657304, 9120210975302316402, 10413575251164819383, 10272571651032974201, 9047581505547301010, 5010124003129065074, 11784915796945300637, 12289884941604530018, 9340048338271037591, 10056399084670915440, 9915642911869266805, 7967353223478673277, 10780060064511123847, 11065770399018485618, 9408709571490508183, 9768175068110159977, 9550008892990843280, 12651625607488571533, 6668827724406811020, 7750034631009794418, 11355389333437901455, 9767894856842309978, 12356600210706362293, 9552000130175234409, 10268055995112910981, 9912842335560698223, 10201909401623028627, 11137845464463410288, 9267409176064321687, 13804247112655733377, 7822872921188885404, 10273208237729545329, 8322489935304484231, 10272859804532051828, 8760189004383150984, 10849608491880120689, 9408710718080379798, 12289919271877705096, 7319314196209104530, 9480506594040052076, 10201624559358275736, 11354012856240405112, 10417797405763333280, 10489602090836198762, 9193375750974106255, 11498697561594295157, 10780330561433530245, 11354553769170995318, 7677067779363530378, 9408743630178253431, 6814349191712760193, 9985206526291383405, 6526118695403679109, 11642244302830465137, 7897186798736076671, 10417253177824281970, 9550566452925330319, 10993434572318277234, 8400466273565302938, 10417816063084819320, 9198438937661957747, 10417800468058962799, 8470825006090644112, 10345495741787244402, 8690376617432935549, 10345482350247179888, 9125254357041704055, 11929922835378766961, 8399332565174021481, 8904056768284423283, 7825688774663433552, 9480205301881534066, 9269383847492022909, 9768741355387057274, 9196752372739043208, 9984910864550883959, 9910011084629042832, 10345483771446065013, 9192249829659598444, 11210173667378692980, 8409469074621426534, 10200821894564116850, 8256906291584199291, 10129023927104207227, 8832806280005118336, 10272590368281362541, 8620574061582119506, 10128162915430857841, 9763083346010861969, 8111113244500725380, 10279011228490954633, 10416689823910622836, 10135475809511434397, 10129015062107292014, 9044759145249139350, 10561097752844071028, 9770115774920224910, 9552872021052188026, 7396437171748432474, 10561384562203063416, 4726646055758295178, 9768187321986015621, 6596773480679302007, 6235367079915189866, 11133862260656075360, 8975827479897338234, 9979547425725772439, 8903456469680156265, 8823239455032899735, 10489029391574995586, 9466405559344722301, 10128177208024202616, 9103869027765609869, 9551976026969767555, 9769557201503678314, 9047607894177380221, 8972986273100167044, 7531578300655497581, 5014885017565810063, 8834795309389214049, 9768424751821644952, 7826283657847933022, 10340377506433689753, 8979205153662793063, 9771516569911386775, 9483596208894672230, 8974940212501177483, 8763032440419877994, 9193366963353183105, 9627433220462908518, 9119619372682209160, 7681584604336258661, 9842725164612677491, 9338908132631541349, 9485821525689855366, 3646960717148623462, 8607620732390628220, 13807327815923500150, 8686426140557143699, 11140921992821908322, 4939157434154571933, 11573542435023191401, 6161034853161264523, 12437982874727055473, 8829978396008869764, 11212960818003753822, 7822581533092049550, 8618600491023240555, 6673035640717010298, 10852123053027854448, 2486938601817398368, 8474799852628125035, 13007628943970626718, 7393664272108454238, 8838433515736424083, 7322476465638840183, 6883868112471348625, 7970413105852288866, 7602750774627034273, 9123318147313609321, 8472794343084025222, 8474488608277892457, 8758484701128449911, 9122726683794448747, 10131236028099224451, 8329844568649398384, 8116440188889096576, 7465996727677445741, 8544281363650799743, 8258329050987526759, 13293608512278653356, 7033903028418283880, 10129274533614149293, 11717952236380976998, 9191960752287542935, 10132409216132348521, 10990296621766046335, 10060362603906692470, 6741714345528487541, 8619167954383239279, 11572385701194721667, 9340024093647873135, 9190272769895329682, 8115046232017762404, 8045796816214059647, 9627713695432732519, 9978121582045717140, 8042741183441699694, 8764953218261934963, 10420912378038678370, 9340015318910397335, 7682441153086062700, 8761020308152083567, 8258622569152671851, 7103123766107532138, 11068597350821496685, 8689807083111016555, 9843890841251376747, 8109974210301288817, 7682711646064311907, 9041655515827759493, 11141216700524558430, 8393983587182798000, 8763036834623485794, 9185196458087444107, 8330959550831555946, 9038553595959993962, 9123628059101196649, 7967543474021624937, 10924753389611276141, 7610356126640923754, 9339208311752584552, 6530042813780551302, 9339195195108326505, 7895205251167117698, 8619199624804070253, 8968742037836360361, 9483599417019239014, 9112863934620393126, 9627727013487213673, 8256043157741921631, 8835663988250872684, 8182863133963021119, 8763301730457844327, 8541741517392734286, 10132112613863295082, 7747152896632772727, 9771843219607751280, 8460124773509192081, 9411268177846630001, 7245279843391068485, 9483323495734870379, 8827729877834951080, 10492127591567033952, 8465751932520327084, 9483602767192491109, 9045026352207980203, 9555676849559143530, 8034532298114492049, 9988024595479628907, 7744895642363389585, 9699778864987928942, 7819765744109708938, 9050702985301086830, 6017194414044048505, 9410979985841419375, 7533784814164077728, 7607062109890915452, 5743339972102349684, 10274003176114578275, 7614891449215182735, 8039331614830199413, 8900935297556897422, 11858714077067113829, 9758583092080241548, 9696646426050799483, 8970729984812809608, 10849619577021954155, 9193666034979596957, 12434679065072212881, 14799784300516832899, 18342826621050837105, 14889297289241199525, 9264362455433574764, 9846412132429357180, 6958776701388099192, 9121888734770976898, 11138133691498461805, 10282129748562567816, 8327560908667588221, 9904946643844946837, 10849912081475144043, 8472810848745514141, 8687867587936616828, 9475419136441801625, 10417565421895847029, 9631644491715337636, 7535233090441611391, 8328421770723547565, 8400178282989324916, 10557975225706110347, 10129337197456621945, 9047292514546508159, 8904605441381074040, 8527126675813523090, 12218993208466702442, 9267406985665471886, 8976638803112527738, 8185977814299073428, 11786382657576475508, 9107809625898312593, 9048167730246883706, 8759623838427668123, 12362835649290142331, 8766378408905960065, 10200825201252335227, 8971013959742872993, 8760483630464470136, 8906829697854301838, 10994022853954665071, 9193656216651261298, 9264901133754472567, 8182603430227304329, 12075424370161121399, 9341431622983707266, 8832274155249370742, 8975797775821004438, 10849897718919627125, 9555068952774928511, 6742313631242164079, 8399904315683723416, 9264023667808494700, 9265428869571174288, 10345501222096564600, 8978046350095967376, 9624619587102346356, 7676506998335298708, 11066623619588782983, 8108003898599498104, 9409315428033726327, 8323336537699476348, 10994018468911874677, 8763562344878990722, 9336680543095390078, 8688132445551026833, 11354020592232261494, 9845835958204852080, 11282521407930404984, 6966067657648662154, 7247012570751731829, 8685597104762477202, 10994557147717995898, 7393338881005939839, 11066342174676125560, 8040733414964290192, 10129323938556508789, 9191967418246259577, 10273716272331248759, 7756725137676396666, 11570742008889382008, 8474491989123490690, 9841068406966882677, 9334395697940160383, 6742550034313411705, 7317073361598894461, 9696423194441317505, 9699188637882932617, 8039653840473259635, 9260938528627317661, 10201370546100669307, 8760748823371213440, 9480796912186195830, 8903457491415360142, 14524517174556203642, 9053761010054558844, 8832269782469677176, 9982353340629081229, 9841113440183683194, 8186824503365298083, 5876757178599508608, 7947850271948426653, 8256677640341781878, 11932981491975352488, 8039384331224448397, 8757655927361792380, 7679294350824537191, 9032099355433788315, 7966768309046506375, 9325942665609766806, 9913147956792034171, 9044478632329636758, 15318589415897139828, 10695900606320501375, 4725849373953191042, 9182699343096731289, 10358443396973229413, 9046676611467734388, 9420866764252867407, 12434240085133193376, 14680775428544096863, 9341390730398686868, 9708237386635771230, 9989628868693088390, 7402075545154915928, 12291238719451060106, 7691783636446991973, 10208329290618598282, 9203556143060858734, 13732381782509711230, 11078489416886951024, 3580158793693159040, 7258062525289715821, 8911295990991643275, 8267082245827446108, 10204394340129134219, 9708227503966945361, 9268489948278968966, 8338842894519209040, 9338293431693694092, 9924404727127245915, 9123524811927475327, 8195010388523866482, 8254610467649639293, 10572981428852541793, 10928905286663429511, 9204719185559672921, 2864080985630467425, 7258600354248551760, 11427687823426149277, 8555603975567213138, 9484939820223452791, 8267358159107689559, 7605811634308208007, 9203548334090455128, 9051185764220294780, 8915875508815909982, 8327511344289764480, 9780002485113358936, 8685823560619938170, 8915302612558514538, 8328074337228311158, 8915326762806376819, 6741395383524808052, 10212369073054512468, 10780571461716891013, 8123273774402027850, 10704007914210157721, 7906816219028816727, 9767259221747914382, 9420274178942155605, 10343438473221985418, 9348229736026178652, 8907346476119249542, 9707957041386860894, 8760136179941856634, 9563826443036299094, 9194169434405557614, 7041540090225993318, 7177403390837216101, 8339143078523351896, 10492062728651824549, 9995911405492142156, 10277013703136335256, 9276172228172169816, 10203828023039647367, 9492360356120535889, 10124726995968154484, 7834745357468672848, 9191351489299895655, 8915601537399108437, 8469656297438994273, 8842945830359376468, 9191637271911224180, 8626810500697129814, 8551568693971801173, 9131484271882180437, 10281803231622353547, 7402121698537026124, 10410432842033419680, 8338891410502357578, 9405842052964177786, 7834466206169801559, 10769025356603479171, 9132061386401618769, 9979768388086160499, 8339429002866307412, 9399370314525005948, 9852087656949980493, 8260808423221451338, 8122114923711591263, 9348147271781534271, 4807484466262602575, 10349922319274624367, 7906549158066163531, 9119307154057024148, 7618009746096166999, 9615823519631363485, 8771507356108368471, 10625478684725173122, 6969783848037950803, 9829470676108857998, 6466206401780625742, 7827894334441151518, 7905957599062104156, 8689495830710208391, 8915625808393574223, 7987784292796225332, 6753903614032444496, 9111438030925222585, 7042142798422841683, 11208423188542609316, 8050659866539635551, 11694805484527705257, 7402122798150036318, 11272872166346872991, 8843300079630854480, 8814192685777770137, 9059718091358774097, 8094180627058873728, 7761031520365427554, 6391815677538884376, 7762697934198962271, 10427043980021682025, 11203176346878077062, 9488396565146859950, 5799909979337116037, 7684978791259728003, 4646736729500583555, 8324207389780830078, 6808442426640131458, 7380416205132626818, 6376392820118816377, 9545244760915735685, 7601337782481418103, 12501574194906626684, 7169299076219309426, 10777825848578698368, 5727856906642101618, 9762552161569171051, 5151632443135064182, 9040276461776701007, 9547763815555622264, 9412951517213585033, 7097233807543792756, 9538763114098555014, 9547179850477825912, 9686817847891820693, 7529299954033189752, 10479167605347615874, 8033683329260810614, 11060421244767466881, 8033677943372025970, 11134733868451196549, 10051598430731405424, 10554334695562900349, 11564563725646723459, 8616105851982214592, 11565070750561945455, 10839174306784447364, 9403058069273536885, 6867553503524191610, 9908020788747135859, 6587778367308923776, 10051581882722445431, 9621231841840824695, 9259507922047106429, 8817624129177157253, 8898939533358756206, 8390342937030657382, 9114832064762967663, 11127695885831145074, 5800223559996421754, 8821288990257023858, 6520460513839965312, 11274888563867618409, 11061796893462716535, 12707322752141199472, 10485026915342511984, 9827265984385617537, 10555989473745397370, 7813318169505793922, 9835688308395300466, 7748298652391213680, 11493005187649721213, 8466905225593783923, 7170401864554862450, 13645483939285275509, 6810407683429917556, 17192357701338695048, 10412129316065664105, 10337316530702484384, 11709802652001000306, 9387047006454581145, 10340380839982028662, 10685204191594581888, 8322501807244858237, 8318275554679494255, 9763362175069085558, 4211846825989341588, 11709758594308722301, 8392034127667234191, 9403922246239411321, 7092174829868127099, 6303832692943518851, 13362023197115650436, 12069506587822028160, 8612139626619436465, 11348937626915009141, 11700774763791155826, 7746026864368838265, 8667303486587900519, 11780989390297653877, 8029760349232797557, 12285951190126852725, 6947216457910161283, 11925400389615838845, 7887338426191286910, 9186916034997625222, 6809290322067361947, 10627811589439526522, 8820439978541352545, 7529317748096267390, 12145502753043020176, 8034284899892166788, 9472050194479676287, 13222423922735744376, 9403647407324370814, 10628068954802779003, 6300386957286017641, 11420715799340350596, 9117670033508435335, 10411916122511150479, 8755129120941833351, 11708676829336083347, 8683070375853064607, 11564264769897714830, 7753345256414942026, 9835763216602995597, 8616367399150715736, 10339582585414847377, 9553959335426553454, 11132800883570024325, 7816420007874433374, 10988093183569659787, 8322229342858542721, 10484248598782840201, 7241925100888230526, 11564568272607353740, 8544023949449591434, 10700166289805843869, 7317915708011217266};
        UInt64[] w2 = {9845058629790962605, 12363928722395596208, 10228541927243761387, 42612936999279359, 9342046405459815593, 10780672523257681583, 12151163241152228752, 10782929868042704783, 9845895345590146222, 12147219370067327663, 11792853275234250378, 10491002899220635784, 9122242984461047222, 11501515722136787377, 9481421499769002408, 12724793970583247003, 10349163807604183469, 11997491162548182703, 11066929327226661515, 10780655004220629129, 9693007059545249927, 14739033430651083929, 9844759476428188818, 10710014654817411213, 10267495390699102379, 12508307797491882904, 8259774965137190545, 10636256111610461324, 10420075611322823293, 11061825390339000692, 11214417808352391308, 10553785051971493000};
        UInt64[] w3 = {5770539481397855767, 271473916622470912};
        UInt64[][] weights = {w1, w2, w3};
        int[] rows = {16, 16, 1};
        double[][,] quantized_weights = {q_w1, q_w2, q_w3};
        double[] zeros = {-126.63147735595703, -159.31283569335938, -12.807402610778809};
        int count = 0;
        foreach(UInt64[] w in weights){
            for(int x = 0; x < w.Length; x++){
                // convert 64 bit int into a binary string with padding to ensure same length
                string str = Convert.ToString((long) w[x], 2).PadLeft(64, '0');
                // every eight bits is a number, extract it and write to quantized weights
                for(int y = 0; y < 8; y++)
                    quantized_weights[count][(8 * x + y) / rows[count], (8 * x + y) % rows[count]] = Convert.ToInt32(str.Substring(y*8, 8), 2) + zeros[count];
            }
            count++;
        }
    }
    public Move Think(Board board, Timer timer){
        searchMaxTime = timer.MillisecondsRemaining / 50;
        searchTimer = timer;
        for(int depth = 2; depth < 100; depth++){
            bestMoveThisIteration = Move.NullMove;
            bestEvalThisIteration = -100;
            mDepth = depth;
            Search(board, mDepth, -100, 100);
            if(searchCancelled){
                Console.WriteLine(depth);
                break;
            }
            else{
                bestMove = bestMoveThisIteration;
                bestEval = bestEvalThisIteration;

            }
        }
        return bestMove;
    }
    double Eval(double[,] a){
        return PLUG(MatMul(PLUG(MatMul(PLUG(MatMul(a, q_w1), w1_S, b1, true), q_w2), w2_S, b2, true), q_w3), w3_S, b3, false)[0, 0];
    }
    double[,] BoardToBit(Board board){
        double[,] bit = new double[1, 384];
        PieceType[] types = {PieceType.Pawn, PieceType.Knight, PieceType.Rook, PieceType.Bishop, PieceType.Queen, PieceType.King};
        bool[] colors = {true, false};
        int count = 0;
        foreach(PieceType type in types){
            foreach(bool color in colors){
                string c = new String(Convert.ToString((long)board.GetPieceBitboard(type, color), 2).PadLeft(64, '0').Reverse().ToArray());
                for(int i = 0; i < 64; i++)
                    if(int.Parse(c.Substring(i, 1)) != 0)
                        bit[0, count * 64 + i] = (Convert.ToInt32(color) * 2 - 1) * (Convert.ToInt32(board.IsWhiteToMove) * 2 - 1) * int.Parse(c.Substring(i, 1));
            }
            count++; 
        }
        return bit;
    }
    double Search(Board board, int depth, double alpha, double beta){
        if(searchCancelled){
            return 0;
        }

        if (board.IsDraw())
            return 0;
            
        Move[] moves;

        if(depth == 0 || (moves = board.GetLegalMoves()).Length == 0){
            if (board.IsInCheckmate())
                return -9999999;
            return Eval(BoardToBit(board));
        }

        // Move[] moves = MoveOrdering(prior, board);
        double recordEval = double.MinValue;
        
        foreach(Move move in moves){
            board.MakeMove(move);
            double evaluation = -Search(board, depth - 1, -beta, -alpha);
            board.UndoMove(move);

            if(recordEval < evaluation){
                recordEval = evaluation;
                if (depth == mDepth)
                    bestMoveThisIteration = move;
            }
            alpha = Math.Max(alpha, recordEval);
            if (alpha >= beta) break;
        }
        bestEvalThisIteration = recordEval;
        return recordEval;

    }
    // Move[] MoveOrdering(Move[] moves, Board board){
    //     SortedDictionary<double, Move> dict = new SortedDictionary<double, Move>();
    //     for(int i = 0; i < moves.Length; i++){
    //         board.MakeMove(moves[i]);
    //         dict.Add(Eval(BoardToBit(board)), moves[i]);
    //         board.UndoMove(moves[i]);
    //     }
    //     Move[] output = dict.Values.ToArray();
    //     return output;
    // }
    double[,] MatMul(double[,] a, double[,] b){
        double[,] c = new double[a.GetLength(0), b.GetLength(1)];
        for(int row = 0; row < a.GetLength(0); row++)
            for(int col = 0; col < b.GetLength(1); col++){
                double[] x = new double[a.GetLength(1)];
                int i = 0;
                foreach(double t in x)
                    x[i] = a[row, i++];
                double[] y = new double[b.GetLength(0)];
                i = 0;
                foreach(double t in y)
                    y[i] = b[i++, col];
                c[row, col] = Dot(x, y);
            }
        return c;
    }
    double[,] PLUG(double[,] a, double scale, double[,] bias, bool hasReLU){
        double[,] c = new double[a.GetLength(0), a.GetLength(1)];
        for(int row = 0; row < a.GetLength(0); row++)
            for(int col = 0; col < a.GetLength(1); col++){
                if(hasReLU)
                    c[row, col] = Math.Max(0, (a[row, col] * scale) + bias[row, col]);
                else
                    c[row, col] = (a[row, col] * scale) + bias[row, col];
            }
        return c;
    }
    double Dot(double[] a, double[] b)
    {
        double sum = 0;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            sum += a[i] * b[i];
        }
        return sum;
    }
}