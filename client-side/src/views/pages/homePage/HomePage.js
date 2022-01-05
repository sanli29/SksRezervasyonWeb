import React from 'react'
import { CCard, CCardBody, CCardTitle, CCardText } from '@coreui/react'

export default function HomePage(props) {
  const { role } = props
  return (
    <div>
      <CCard style={{ width: '100%', height: '100%' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Anasayfa</CCardTitle>

          <CCardText>
            Bakırçay Üniversitesi Online Rezervasyon Sistemi web ara yüzüne hoş geldiniz. Yandaki
            menüden ilgili adımları takip ederek işlemlerinizi yapabilirsiniz.
          </CCardText>
          <CCardText>
            Ücretler, tahsisin yapıldığı tarihte ilgililerden peşin olarak tahsil edilir.
          </CCardText>
          <CCardText>
            Ücretler Sağlık, Kültür ve Spor Daire Başkanlığınca; 5018 Sayılı Kamu Mali Yönetimi ve
            Kontrol Kanunu gereğince görevlilerden Muhasebe Yetkilisi Mutemedi personel tarafından
            makbuz karşılığı alınır, Strateji Daire Başkanlığının belirlediği banka hesabına
            zamanında yatırılır.
          </CCardText>
          <CCardText>Tesislerimiz hafta sonu ve tatil günlerinde kapalıdır.</CCardText>
          <CCardText>Tesis rezervasyonları bir saatliktir.</CCardText>
          <CCardText>
            Ödemeler yapılmış rezervasyon saatinden en az 24 saat öncesinden yapılmalıdır.
          </CCardText>
          <CCardText>
            Tesislerin kullanım önceliği; okul takımları, kurslar ve düzenlenen turnuvalara aittir.
          </CCardText>
          <CCardText>Tesislerin kullanımında; Covid19 tedbirlerine uyulması esastır.</CCardText>
          <CCardText>
            Tesislerimiz sadece üniversitemiz öğrencileri ile akademik ve idari personelimiz
            tarafından kullanılabilir.
          </CCardText>
        </CCardBody>
      </CCard>
    </div>
  )
}
