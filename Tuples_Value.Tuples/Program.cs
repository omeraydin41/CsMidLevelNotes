
var tuple1 = new Tuple<int, string>(1, "aaa");//new ile oluştururken veri tiplerini (<int, string>) elle yazmak zorundasın.
var tuple2 = Tuple.Create(2, "w");//Tuple.Create veri tiplerini otomatik anladığı için kodu kısa tutar

var a = tuple1.Item1;//item ismi kullanılmak zorunda 
var b = tuple2.Item1;

var largeTuple1 = Tuple.Create(1,2,3,4,5,6,7);//max 7 karakter alır
var largeTuple2 = Tuple.Create((1, 2, 3, 4, 5, 6, 7, Tuple.Create(1, 2, 3)));//bu şekilde birden fazla değer alabılır
//ikinci yapıda iç içe Tuple gömerek artabilir /NESTED YAPI DENİR.


//Özellik Tuple(Eski)                                                                   ValueTuple(Modern)
//Bellek Türü	Class (Referans): Heap bellek kullanır, yavaştır.	                    Struct (Değer): Stack bellek kullanır, çok hızlıdır.
//Değiştirilebilirlik	Immutable (Değişmez): Elemanları sonradan değiştirilemez.	    Mutable (Değişebilir): Eleman değerleri güncellenebilir.
//Eleman İsimleri	Kısıtlı: Sadece Item1, Item2 kullanılabilir.	                    Esnek: (sayi: 5, metin: "a") gibi isimler verilebilir.
//referans tipli                                                                        value tipli

var valueTuple1 = new ValueTuple<int, string>(1, "ccc");
var valueTuple2 =  ValueTuple.Create(1, "ccc");


Console.WriteLine(valueTuple1==valueTuple2);//true doner 
Console.WriteLine(tuple1==tuple2);//false döner 

//value tip ve referans tip