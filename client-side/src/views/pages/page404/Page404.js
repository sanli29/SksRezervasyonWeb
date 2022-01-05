//Anasayfaya dönerken login olunmuş mu diye kontrol et

import React from 'react'
import { CButton, CCol, CContainer, CRow } from '@coreui/react'
import { Link } from 'react-router-dom'

const Page404 = () => {
  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={6}>
            <div className="clearfix">
              <h1 className="float-start display-3 me-4">404</h1>
              <h4 className="pt-3">Görünen o ki kaybolmuşsunuz!</h4>
              <p className="text-medium-emphasis float-start">
                Aradığınız sayfa bulunamadı. Anasayfaya geri dönebilirsiniz.
              </p>
            </div>
            <div style={{ textAlign: 'center', marginTop: '20px' }}>
              <Link to="/Homepage">
                <CButton color="primary" className="px-4">
                  ANASAYFAYA DÖN
                </CButton>
              </Link>
            </div>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Page404
