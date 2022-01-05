import React from 'react'
import { CCard, CCardBody, CCardTitle, CCardText } from '@coreui/react'

export default function Iletisim() {
  return (
    <div>
      <CCard style={{ width: '100%', height: '100%', marginBottom: '30px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Bakırçay Üniversitesi</CCardTitle>
          <CCardText>
            Adres: Gazi Mustafa Kemal Mahallesi, Kaynaklar Caddesi Seyrek,Menemen, İzmir
          </CCardText>
          <CCardText>Telefon: 0 232 493 00 00</CCardText>
          <CCardText>Faks: 0 232 844 71 22</CCardText>
          <CCardText>E-Posta: info@bakircay.edu.tr</CCardText>
          <CCardText>KEP:bakircay.universitesi@hs01.kep.tr</CCardText>
          <a
            href="https://bakircay.edu.tr/"
            target="_blank"
            rel="noopener noreferrer"
            style={{ textDecoration: 'none', color: '#00a5b5' }}
          >
            İnternet Sitesi: https://bakircay.edu.tr/
          </a>
        </CCardBody>
      </CCard>

      <CCard style={{ width: '100%', height: '100%' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>
            Bakırçay Üniversitesi Sağlık Kültür Spor Daire Başkanlığı
          </CCardTitle>
          <CCardText>İzmir Bakırçay Üniversitesi Seyrek Yerleşkesi E-Blok Zemin Kat</CCardText>
          <CCardText>Gazi Mustafa Kemal Mah. Kaynaklar Cad. Seyrek, Menemen / İZMİR</CCardText>
          <CCardText>Telefon Numarası: 0(232) 493 00 00 / 11162</CCardText>
          <CCardText>Faks: 0(232) 844 71 22</CCardText>
          <CCardText>e-Posta: sksdb@bakircay.edu.tr</CCardText>
          <a
            href="https://sks.bakircay.edu.tr/"
            target="_blank"
            rel="noopener noreferrer"
            style={{ textDecoration: 'none', color: '#00a5b5' }}
          >
            İnternet Sitesi: https://sks.bakircay.edu.tr/
          </a>
        </CCardBody>
      </CCard>
    </div>
  )
}
