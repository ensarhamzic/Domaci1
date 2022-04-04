<h1>Domaci zadatak iz predmeta objektno orijentisano programiranje 2</h1>

Kreirati konzolnu aplikaciju CHAT koja će ilustrovati razmenu poruka u jednoj IT kompaniji. U kompaniji rade Developeri i QA. Developeri su zaduženi za razvoj softvera, dok su QA zaduženi za testiranje. Korisniku aplikacije omogućiti da bira jednu od opcija:

1 unos, izmena i brisanje podataka o programerima, gde se pritiskom na ovaj izbor otvaraju novi izbori. 

1-unos novog Developera <br/>
2-izmena Developera <br/>
3-brisanje Developera <br/>
4-unos novog QA <br/>
5-izmena QA <br/>
6-brisanje QA <br/>
0-nazad <br/> <br/>
ako je izbor izmena ili brisanje, unosi se ID programera i proverava se da li on postoji, a ako postoji onda se vrši unos novih podataka za izmenu (ime, prezime, plata) 
<br/><br/>
2-slanje poruka

Ovde korisnik unosi id Developera i a zatim ako je id ispravan unosi poruku. 

Ako poruka ima prefiks "feature/ tekst poruke onda ova poruka treba da se šalje samo objektima klase Developer, a ako ima testing/ tekst poruke onda ide samo objektima klase QA. Ako nema neki od ova dva prefiksa onda poruka ide svim programerima. 

Kada pristignu neka poruka objektu developer ili qa ispisuje se automatski preko konzole i u njoj piše ime programera koji je dobio poruku(tip zaposlenog ako je Developer pisaće DEV, a ako je QA pisaće QA) : ime programera koji je poslao poruku i tekst poruke. 
