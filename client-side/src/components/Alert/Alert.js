import React from 'react'
import { Notification } from 'react-pnotify'

export default function Alert({ props }) {
  return (
    <Notification type={props.typeOfAlert} title={props.title} text={props.text} delay={3000} />
  )
}
