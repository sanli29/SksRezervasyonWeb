import React from 'react'
import { CCard, CCardBody, CCardTitle, CCardText } from '@coreui/react'

export default function Iletisim() {
  return (
    <div>
      <CCard style={{ width: '100%', height: '100%', marginBottom: '30px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Bakırçay Üniversitesi</CCardTitle>
          <CCardText>
            <p>Adres: Gazi Mustafa Kemal Mahallesi, Kaynaklar Caddesi Seyrek,Menemen, İzmir</p>
            <p>Telefon: 0 232 493 00 00</p>
            <p>Faks: 0 232 844 71 22</p>
            <p>E-Posta: info@bakircay.edu.tr</p>
            <p>KEP:bakircay.universitesi@hs01.kep.tr</p>
            <a
              href="https://bakircay.edu.tr/"
              target="_blank"
              rel="noopener noreferrer"
              style={{ textDecoration: 'none', color: '#00a5b5' }}
            >
              İnternet Sitesi: https://bakircay.edu.tr/
            </a>
          </CCardText>
        </CCardBody>
      </CCard>

      <CCard style={{ width: '100%', height: '100%' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>
            Bakırçay Üniversitesi Sağlık Kültür Spor Daire Başkanlığı
          </CCardTitle>
          <CCardText>
            <p>İzmir Bakırçay Üniversitesi Seyrek Yerleşkesi E-Blok Zemin Kat</p>
            <p>Gazi Mustafa Kemal Mah. Kaynaklar Cad. Seyrek, Menemen / İZMİR</p>
            <p>Telefon Numarası: 0(232) 493 00 00 / 11162</p>
            <p>Faks: 0(232) 844 71 22</p>
            <p>e-Posta: sksdb@bakircay.edu.tr</p>
            <a
              href="https://sks.bakircay.edu.tr/"
              target="_blank"
              rel="noopener noreferrer"
              style={{ textDecoration: 'none', color: '#00a5b5' }}
            >
              İnternet Sitesi: https://sks.bakircay.edu.tr/
            </a>
          </CCardText>
        </CCardBody>
      </CCard>
    </div>
  )
}
