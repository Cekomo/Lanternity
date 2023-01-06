using System.Collections.Generic;
using UnityEngine;

namespace Spirit
{
    public class SpiritController : MonoBehaviour
    {
        public List<GameObject> spirits;
    }

}
/*
 * bir mapte 15 adet spirit olsun
 * bu spiritler normalde disabled pozisyonda olacaklar
 * spirite yeterince yaklaşıldığında lantern titremeye (veya başka bir aksiyon) başlar
 * lantern ile scanning yapıldığında spiritler enabled olacak
 * laneternin beam'i ile spirite bakıldığında ise spiritler parlak olarak gözükecek
 * son olarak lanternin içine çekilerek ruh kazanılmış olacak
 *
 * oyunun efektif çalışması adına bir controller yardımı ile animasyonlar tek bir gameobject
 * ..üzerinden kontrol edilecekler, spiritlerin lightcontrollera bağlanmasına gerek yok
 * lantern tarafından algılanabilmek için tüm spiritlerin bireysel collidera ihtiyacı olacak
 * controller üzerindeki script ile bu colliderların yeri geldiğinde tetiklenebileceğini düşünüyorum
 */