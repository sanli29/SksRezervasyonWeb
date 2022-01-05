import React from 'react'
import { CFooter } from '@coreui/react'

const AppFooter = () => {
  return (
    <CFooter>
      <div>
        <a
          href="https://sks.bakircay.edu.tr/"
          target="_blank"
          rel="noopener noreferrer"
          style={{ textDecoration: 'none', color: 'black' }}
        >
          Bakırçay SKS
        </a>
      </div>
    </CFooter>
  )
}

export default React.memo(AppFooter)
