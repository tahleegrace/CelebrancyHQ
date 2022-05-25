import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import App from './App';
import { Dashboard } from './pages/dashboard/dashboard';
import { Login } from './pages/login/login';
import reportWebVitals from './reportWebVitals';
import AuthenticatedRoute from './route-guards/authenticated-route';
import UnauthenticatedOnlyRoute from './route-guards/unauthenticated-only-route';
import configureDependencies from './services/configure-dependencies';

configureDependencies();

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<App />}>
                    <Route path="login" element={<UnauthenticatedOnlyRoute><Login /></UnauthenticatedOnlyRoute>} />
                    <Route path="dashboard" element={<AuthenticatedRoute><Dashboard /></AuthenticatedRoute>} />
                </Route>
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
