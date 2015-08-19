using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("en_US.dic").Select(Preprocess).ToArray();
        }

        static string Preprocess(string src)
        {
            return src.Split('/').First().ToLower();
        }

        /*
         arius
darius
marius
markus
markup

doyen
dozen
cozen
cohen
coven
covey
covet
comet
comer
comber
somber
bomber

cammed
rammed
hammed
lammed
dammed
dimmed
rimmed
trimmed
primmed
primmer
grimmer
glimmer
glummer
plummer
plumber
lumber
number
numbers

swoop
swoon
spoon
spook
spool
spoor
poor
poop
loop
sloop
scoop
coop
crop
drop
drip
rip
hip
pip
vip

accent
ascent
scent
scant
cant
want
wart
hart
fart
cart
mart
matt
catt
capt
rapt
rat
rate
kate
katy
         
         */
    }
}
