import http from 'k6/http';

export const options = {
    vus: 10,
    duration: '30s',
};

export default function () {
  const url = 'http://localhost:5076/Leak';
  http.post(url);
}
