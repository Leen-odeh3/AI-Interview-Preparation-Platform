import React from 'react'
import TeamsLogo from '../../assets/teams.png'
import ZoomLogo from '../../assets/zoom.jpg'
import GoogleMeetLogo from '../../assets/googlemeet.png';

const IntegrateMeeting = () => {
  return (
    <div className="mx-auto w-full mt-6 text-white flex flex-col items-center py-14 rounded-lg bg-headingText">
      <p className='text-2xl font-semibold mb-4'>
        AI Interview Prep & <span className="font-bold">Copilot </span>
      </p>
      <p className="text-center mt-2 mb-6 text-sm w-2/3 text-[rgb(226 232 240)]">
        Never miss a beat during your interview. Interview AI provides real-time suggestions and live transcription to help you stay on track during your interview and make a lasting impression.
      </p>

      <div className='flex justify-center gap-6 mt-4'>
        <img src={TeamsLogo} alt="Microsoft Teams" className="logo" />
        <img src={ZoomLogo} alt="Zoom" className="logo" />
        <img src={GoogleMeetLogo} alt="Google Meet" className="logo" />
      </div>
    </div>

  )
}

export default IntegrateMeeting
