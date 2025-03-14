/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#747686",
        secondary: "#212126",
        textcolor:"white",
        mainColor:"#4845D2",
        headingText:"rgb(2, 1, 90)",
      },
    },
  },
  plugins: [],
}