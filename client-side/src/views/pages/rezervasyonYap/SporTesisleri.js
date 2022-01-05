import React, { useState } from 'react'
import {
  CCard,
  CCardBody,
  CCardTitle,
  CCardText,
  CFormSelect,
  CButton,
  CContainer,
  CForm,
  CRow,
  CCol,
} from '@coreui/react'
import { Link } from 'react-router-dom'
import DatePicker from 'react-date-picker'

export default function SporTesisleri() {
  const [folders] = useState([
    {
      folderId: 1,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 2,
      isFile: false,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 3,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 4,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 5,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
  ])
  const [value, onChange] = useState(new Date())
  return (
    <div>
      <CCard style={{ width: '100%', height: '100%', marginBottom: '30px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Spor Tesisleri İçin Rezervasyon</CCardTitle>
          <CCardText>
            <h6>
              Tesisler için tespit edilen ücretler, tahsisin yapıldığı tarihte ilgililerden peşin
              olarak tahsil edilir.
            </h6>
            <h6>
              Kurum dışı ve özel talep kullanımları üniversite yönetiminin onayı ile
              gerçekleşebilir.
            </h6>
            <h6>Tesislere, spora uygun olmayan ayakkabı ve kıyafetler ile girilmez.</h6>
          </CCardText>
        </CCardBody>
      </CCard>

      <div className="d-flex flex-row align-items-center">
        <CContainer>
          <CRow className="justify-content-center">
            <CCol md={6}>
              <CForm>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>
                  Rezervasyon yapmak istediğiniz tesisi seçiniz
                </h5>
                <CFormSelect className="mb-4">
                  <option style={{ textAlign: 'center' }} value="1">
                    Halısaha
                  </option>
                  <option style={{ textAlign: 'center' }} value="2">
                    Tenis Kortu
                  </option>
                  <option style={{ textAlign: 'center' }} value="3">
                    Basketbol Sahası
                  </option>
                </CFormSelect>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>Tarih seçiniz </h5>
                <div style={{ textAlign: 'center', marginBottom: '50px' }}>
                  <DatePicker className="bg-secondary" onChange={onChange} value={value} />
                </div>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>Saat seçiniz </h5>
                <CFormSelect className="mb-4" aria-label="Default select example">
                  <option style={{ textAlign: 'center' }}>Saatler</option>
                  <option style={{ textAlign: 'center' }} value="1">
                    09:00-10:00
                  </option>
                  <option style={{ textAlign: 'center' }} value="2">
                    10:00-11:00
                  </option>
                  <option style={{ textAlign: 'center' }} value="3">
                    11:00-12:00
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
