import React, { useState } from 'react'
import {
  CFormSelect,
  CCard,
  CCardBody,
  CCardTitle,
  CCardText,
  CButton,
  CContainer,
  CRow,
  CForm,
  CCol,
} from '@coreui/react'
import { Link } from 'react-router-dom'
import DatePicker from 'react-date-picker'

export default function Misafirhane() {
  const [value, onChange] = useState(new Date())
  return (
    <div>
      <CCard style={{ width: '100%', height: '100%', marginBottom: '60px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Misafirhane İçin Rezervasyon</CCardTitle>
          <CCardText>
            <h6>
              Konaklamak için belirlenen ücretler personel ile alt-üst soy aileleri ve öğrenciler
              için geçerlidir.
            </h6>
            <h6>
              Konaklamalarda 0-6 yaş arası çocuklardan ücret alınmaz. 7-14 yaş için belirlenen
              ücretin yarısı, 15 yaş ve üzeri için tam yatak ücreti alınır.
            </h6>
            <h6>Odalarda harici kamu kurum personelleri konaklatılmaz.</h6>
            <h6>
              Üniversite Yönetim Kurulu; Tesislerin ücretlerinde ve kullanım haklarında değişiklik
              yapma hak ve yetkisine sahiptir.
            </h6>
          </CCardText>
        </CCardBody>
      </CCard>

      <div className="d-flex flex-row align-items-center">
        <CContainer>
          <CRow className="justify-content-center">
            <CCol md={6}>
              <CForm>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>
                  Rezervasyon yapmak istediğiniz tarihi seçiniz
                </h5>
                <div style={{ textAlign: 'center', marginBottom: '60px' }}>
                  <DatePicker className="bg-secondary" onChange={onChange} value={value} />
                </div>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>Odanın türünü seçiniz</h5>
                <CFormSelect className="mb-5">
                  <option style={{ textAlign: 'center' }} value="1">
                    Standart
                  </option>
                  <option style={{ textAlign: 'center' }} value="2">
                    Deluxe
                  </option>
                  <option style={{ textAlign: 'center' }} value="3">
                    King
                  </option>
                </CFormSelect>
                <CRow>
                  <div style={{ textAlign: 'center' }}>
                    <Link to="/ogrenci/Homepage">
                      <CButton color="info" className="px-4">
                        REZERVASYON YAP
                      </CButton>
                    </Link>
                  </div>
                </CRow>
              </CForm>
            </CCol>
          </CRow>
        </CContainer>
      </div>
    </div>
  )
}
