=== 1 ===


--- Unity
2D template
Högerklicka i project window (längst ner) för att skapa filer/mappar (Create/C# Script)

Game Objects (GO) är objekt i spelet (karaktärer, kamera, level etc). Man kan se alla GO i en level i Hierchy Window
Scripts i unity ärver av Monobehaviour vilket betyder att de kan läggas som komponenter på Game Objects

Monobehaviours har metoderna
Start(): aktiveras när spelet startas/objektet spawnar
Awake(): samma som start men innan Start
Update(): en gång per frame/tick
FixedUpdate(): som Update men specifikt för fysiksystemet

Monobehaviours har inga constructors, start/awake används istället


--- Character Controller
Singleton för att enkelt kunna nå senare

en variabel med [SerializeField] eller public kan man se i inspektorn på ett GO. Kan användas för at debugga elelr assigna värden till variabler utanför kod
.GetComponent<ComponentType>(): hittar en komponent (monobehaviour) på samma GO

Använder Rigidbody2D på karaktären för att flytta på den (fysiksystem dvs fixed update)

FollowTransform sätts på kameran för att följa spelaren


--- Enemy
Använder:
*SimpleAI, följer spelaren rakt av, eftersom den inte använder fysiksystemet görs det i vanlig Update
*DestroyByDamage (IDamagable), förstör Enemy GO när det skadas


--- Shooting
LookAtMouse används för att sikta
Cannon spawnar attacken
DestroyByTimer förstör attacker som missar fiender
DamageOnHit skadar fiender som träffas samt förstör attacken efter träff
