"""
By Nathan (python3)
"""

from bit import Key, base58

class Lego(object):
    
    """
    from: http://www.bartneck.de/wp-content/uploads/2016/09/2010-LEGO-color-palette.pdf
    and: http://www.bartneck.de/2016/09/09/the-curious-case-of-lego-colors/
    also cool: https://www.flickr.com/photos/126975831@N07/15801189140
    2016 codes:
    001 - white
    005 - brick yellow
    006 - light green
    007 - orange
    018 - nougat
    021 - bright red
    023 - bright blue
    024 - bright yellow
    026 - black
    028 - dark green
    037 - bright green
    038 - dark orange
    102 - medium blue
    106 - bright orange
    119 - bright yellow-green
    124 - bright reddish-violet
    131 - silver
    135 - sand blue
    138 - sand yellow
    140 - earth blue
    141 - earth green
    148 - metallic dark grey
    151 - sand green
    154 - dark red
    182 - flame yellow-orange
    192 - reddish brown
    194 - medium stone grey
    199 - dark stone grey
    208 - light stone grey
    211 - light royal blue
    221 - bright purple
    222 - light purple
    226 - cool yellow
    268 - medium lilac
    283 - light nougat
    294 - phosphorous green
    297 - warm gold
    308 - dark brown
    311 - transparent bright breen
    312 - medium nougat
    """
    
    number_lookup = {
        "001": "whi",
        "005": "bye",
        "006": "lgr",
        "007": "ora",
        "018": "nug",
        "021": "bre",
        "023": "bbl",
        "024": "bye",
        "026": "bla",
        "028": "dgr",
        "037": "bgr",
        "038": "dor",
        "102": "mbl",
        "106": "bor",
        "119": "byg",
        "124": "brv",
        "135": "sbl",
        "138": "sye",
        "140": "ebl",
        "141": "egr",
        #"mdg": ? metallic dark grey
        "151": "sgr",
        "154": "dre",
        "191": "fyo",
        "192": "rbr",
        "194": "msg",
        "199": "dsg",
        "208": "lsg",
        "212": "lrb",
        "221": "bpr",
        "222": "lpr",
        "226": "cye",
        "268": "mli",
        "283": "lng",
        #"phg": ? phosphorous green
        "297": "wgl",
        "308": "dbr",
        #"mng": ? medium nougat 
    }
    
    lookup = {
        "whi": 0xD9D9D6,
        "bye": 0xD3BC8D,
        "nug": 0xE59E6D,
        "bre": 0xEF3340,
        "bbl": 0x003DA5,
        "bye": 0xFFCD00,
        "bla": 0x27251F,
        "dgr": 0x00843D,
        "bgr": 0x9639,
        "dor": 0xB86125,
        "mbl": 0x6CACE4,
        "bor": 0xFF8200,
        "byg": 0xB5BD00,
        "brv": 0xAF1685,
        #"slv": ? silver
        "sbl": 0x5B7F95,
        "sye": 0x9B945F,
        "ebl": 0x3865,
        "egr": 0x2C5234,
        #"mdg": ? metallic dark grey
        "sgr": 0x789F90,
        "dre": 0x9B2743,
        "fyo": 0xFFA300,
        "rbr": 0x7A3E3A,
        "msg": 0xA2AAAD,
        "dsg": 0xC1C6C8,
        "lsg": 0x5B6770,
        "lrb": 0x69B3E7,
        "bpr": 0xE93CAC,
        "lpr": 0xF1A7DC,
        "cye": 0xFBDB65,
        "mli": 0x330072,
        "lng": 0xFCC89B,
        #"phg": ? phosphorous green
        "wgl": 0xFDBE87,
        "dbr": 0x31261D,
        #"mng": ? medium nougat 
        "lgr": 0xA2E4B8,
        "ora": 0xF68D2E,
    }


    @classmethod
    def lego_to_hex(cls, key):
        translated = cls.number_lookup.get(key)
        if translated:
            return cls.lookup[translated]
    
        return cls.lookup.get(key, None)

    @classmethod
    def key_to_hex(cls, key_str):
        hex_value = ''
        for key in key_str.split(' '):
            if key:
                value = cls.lego_to_hex(key)
                if value:
                    hex_value += "%6x" % value
                else:
                    print("Invalid value!", key)
                    hex_value += hex(0xffffff)[2:]
        return hex_value
  
def check_bitcoin_key(key):
    bit_key = Key(key)
    return bit_key.get_balance('usd')
  
if __name__ == "__main__":     
    width = 12 * 4
    height = 5
    bytes_per_block = 1

    key_len = 256 #width * height * bytes_per_block
    print("key length:", key_len)

    key_segments = [
        "mbl cye msg bre",
        "mbl lgr mbl cye",
        "mbl lgr mbl lgr",
        "mbl cye mbl bre",
        "mbl lgr msg cye",
        "mbl cye cye cye",
        "mbl lgr mbl cye",
        "mbl cye mbl lgr",
        "mbl cye dgr cye",
        "mbl lgr msg cye",
        "mbl msg bre msg",
        "mbl msg bre bre",
        "mbl msg dgr bre",
        "mbl lgr mbl dgr",
        "mbl lgr mbl cye",
        "mbl cye dgr lgr",
        "mbl lgr mbl msg",
        "mbl cye cye mbl",
        "mbl lgr cye cye",
        "mbl msg bre lgr",
        "mbl cye cye dgr",
        "mbl cye dgr bre",
        "mbl lgr mbl dgr",
        "mbl msg cye dgr", 
        "mbl cye bre bre",
        "mbl msg bre cye",
        "mbl msg cye dgr",
        "mbl msg bre bre",
        "mbl lgr msg msg", # key should end here   
    ]

    key = Lego.key_to_hex(' '.join(' '.join(key_seg.split(' ')[1:]) for key_seg in key_segments))

    for potential_public_key_idx in range(0, len(key), 64):
        pot_key = key[potential_public_key_idx:potential_public_key_idx + 64]
        b58_pot_key = base58.b58encode(pot_key.encode('ascii'))
        print(pot_key)
        print(b58_pot_key)
        # check_bitcoin_key(b58_pot_key)

    print("actual length:", len(key) / 2)
