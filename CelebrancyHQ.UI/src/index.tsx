import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { App } from './App';
import CeremonyDetails from './pages/ceremonies/ceremony-details/ceremony-details';
import CeremonyDates from './pages/ceremonies/ceremony-details/dates/dates';
import CeremonyKeyDetails from './pages/ceremonies/ceremony-details/key-details/key-details';
import CeremonyParticipants from './pages/ceremonies/ceremony-details/participants/participants';
import CeremonyMeetings from './pages/ceremonies/ceremony-details/meetings/meetings';
import { MyCeremonies } from './pages/ceremonies/my-ceremonies/my-ceremonies';
import { Dashboard } from './pages/dashboard/dashboard';
import DefaultPage from './pages/default/default-page';
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
                    <Route path="" element={<DefaultPage />} />
                    <Route path="login" element={<UnauthenticatedOnlyRoute><Login /></UnauthenticatedOnlyRoute>} />
                    <Route path="dashboard" element={<AuthenticatedRoute><Dashboard /></AuthenticatedRoute>} />
                    <Route path="ceremonies" element={<AuthenticatedRoute><MyCeremonies /></AuthenticatedRoute>} />
                    <Route path="ceremonies/:ceremonyId" element={<AuthenticatedRoute><CeremonyDetails /></AuthenticatedRoute>}>
                        <Route path="" element={<AuthenticatedRoute><CeremonyKeyDetails /></AuthenticatedRoute>} />
                        <Route path="dates" element={<AuthenticatedRoute><CeremonyDates /></AuthenticatedRoute>} />
                        <Route path="participants" element={<AuthenticatedRoute><CeremonyParticipants /></AuthenticatedRoute>} />
                        <Route path="meetings" element={<AuthenticatedRoute><CeremonyMeetings /></AuthenticatedRoute>} />
                    </Route>
                </Route>
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
